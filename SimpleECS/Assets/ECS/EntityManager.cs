using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SimpleECS.Internal	// putting it in this name space to clean up Intellisense and hide unnecessary classes
{
	public delegate void EntityEvent<E>(Entity entity, E args);

	[DisallowMultipleComponent]
	public sealed class EntityManager : MonoBehaviour
	{
		public static bool loaded; // static so I can query this value without the singleton being loaded

		public static EntityManager instance; 	// yes it's singleton pattern

		[HideInInspector]
		public int totalEntityCount; 	// this and the systems list below are only used for the custom inspector nothing else


		#if UNITY_EDITOR
		public List<EntitySystemInfo> SystemsInfo = new List<EntitySystemInfo>();	// systems is added to by the system on awake
		public int SystemInfoIndex;
		System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
		public double UpdateTime;
		public double FixedUpdateTime;
		#endif

		int ComponentCount = -1; 	// Cache of how many components are in the Assembly
		public Dictionary<System.Type, int> componentIDLookup = new Dictionary<System.Type, int>();	// Lookup table for component ID's

		public Action UpdateCallback = delegate {};			// this is the actual update callback, Systems just register thier Update calls to this
		public Action FixedUpdateCallback = delegate {};	// same as above except with fixed update

		void Awake()
		{
			if (loaded) // loaded means another instance exists so destroy this instance
			{
				Destroy(this);
				return;
			}
			instance = this;
			loaded = true;
			DontDestroyOnLoad(gameObject);

			var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();	// populates component IDs
			foreach (var assembly in assemblies)
			{
				foreach(var type in assembly.GetTypes())
				{
					if (type.IsSubclassOf(typeof(EntityComponent)) && !type.IsAbstract)
					{
						componentIDLookup.Add(type, componentIDLookup.Count);
					}
				}
			}
			ComponentCount = componentIDLookup.Count;
		}


		void OnDestroy()
		{
			if (instance != this) return;
			UpdateCallback = null;			// clear out delegates to avoid possible weak references
			FixedUpdateCallback = null;
			loaded = false;
		}

		void Update()
		{
			#if UNITY_EDITOR
			timer.Reset();
			timer.Start();
			#endif

			UpdateCallback();

			#if UNITY_EDITOR
			timer.Stop();
			UpdateTime = timer.Elapsed.TotalMilliseconds;
			#endif
		}

		void FixedUpdate()
		{
			#if UNITY_EDITOR
			timer.Reset();
			timer.Start();
			#endif

			FixedUpdateCallback();
			#if UNITY_EDITOR
			timer.Stop();
			FixedUpdateTime = timer.Elapsed.TotalMilliseconds;
			#endif
		}

		int newEntityId;				
		public int GetEntityID	// small simple function to doll out unique Entity ID's
		{
			get {return ++newEntityId;}
		}

		public int GetComponentCount()	// Returns Total amount of Entity Components
		{
			return ComponentCount;
		}

		int GetEntityComponentID<C>() // Retrieve Component ID's, the ID is the array position of the component inside the entity's component array
		{
			int id;
			if (componentIDLookup.TryGetValue(typeof(C), out id))
				return id;
			return -1;
		}

		#region GetGroups

		public Dictionary<Type, Group> groupLookup = new Dictionary<Type, Group>();

		public Group<C> GetGroup<C>() where C : EntityComponent<C>	// Returns an instance of a group, gets called during Group Instantiation
		{
			Group<C> newGroup = new Group<C>(GetEntityComponentID<C>());

			groupLookup[typeof(Group<C>)] = newGroup;
			return newGroup;
		}

		public Group<C1, C2> GetGroup<C1, C2>() 
			where C1 : EntityComponent<C1>
			where C2 : EntityComponent<C2>
		{
			Group<C1, C2> newGroup = new Group<C1,C2>();
			groupLookup[typeof(Group<C1,C2>)] = newGroup;
			return newGroup;
		}

		public Group<C1, C2, C3> GetGroup<C1, C2, C3>() 
			where C1 : EntityComponent<C1>
			where C2 : EntityComponent<C2>
			where C3 : EntityComponent<C3>
		{
			Group<C1, C2, C3> newGroup = new Group<C1,C2,C3>();
			groupLookup[typeof(Group<C1,C2,C3>)] = newGroup;
			return newGroup;
		}

		public Group<C1, C2, C3, C4> GetGroup<C1, C2, C3, C4>() 
			where C1 : EntityComponent<C1>
			where C2 : EntityComponent<C2>
			where C3 : EntityComponent<C3>
			where C4 : EntityComponent<C4>
		{
			Group<C1, C2, C3, C4> newGroup = new Group<C1,C2,C3,C4>();
			groupLookup[typeof(Group<C1,C2,C3,C4>)] = newGroup;
			return newGroup;
		}

		public Group<C1, C2, C3, C4, C5> GetGroup<C1, C2, C3, C4, C5>() 
			where C1 : EntityComponent<C1>
			where C2 : EntityComponent<C2>
			where C3 : EntityComponent<C3>
			where C4 : EntityComponent<C4>
			where C5 : EntityComponent<C5>
		{
			Group<C1, C2, C3, C4, C5> newGroup = new Group<C1,C2,C3,C4,C5>();
			groupLookup[typeof(Group<C1,C2,C3,C4,C5>)] = newGroup;
			return newGroup;
		}
		#endregion

		#region Events

		public Dictionary<int , object> entityEventLookup = new Dictionary<int, object>();				// Lookup table for Events, same reason as above
		public Dictionary<int , object> systemEventLookup = new Dictionary<int, object>();

		/// <summary>
		/// Entity Events
		/// </summary>

		public class EntityEventHolder<E>	// helper class to store Event delegate
		{
			public EntityEvent<E> entityEvent = delegate {};
		}

		public class SystemEventHolder<E>
		{
			public Action<E> systemEvent = delegate {};
		}

		public class EventID
		{
			protected static int id;
		}

		public class EventID<C>:EventID	// cheap trick to lookup Events using Int instead of Type
		{
			static bool hasID;
			static int _id;
			public static int ID
			{
				get
				{
					if (hasID) return _id;
					hasID = true;
					_id = id++;
					return _id;
				}
			}
		}

		public void AddEntityEvent<E>(EntityEvent<E> callback) // Adds an Event Listener
		{
			object e;
			if (entityEventLookup.TryGetValue(EventID<E>.ID, out e))
			{
				((EntityEventHolder<E>)e).entityEvent += callback;
				return;
			}

			EntityEventHolder<E> newEvent = new EntityEventHolder<E>();
			newEvent.entityEvent += callback;

			entityEventLookup.Add(EventID<E>.ID, newEvent);
		}

		public void RemoveEntityEvent<E>(EntityEvent<E> callback)	// Removes Event Listener
		{
			object e;
			if (entityEventLookup.TryGetValue(EventID<E>.ID, out e))
			{	
				((EntityEventHolder<E>)e).entityEvent -= callback;
			}
		}

		public void CallEntityEvent<E>(Entity entity, E args)	// Calls Event with Arguments
		{
			object e;
			if (entityEventLookup.TryGetValue(EventID<E>.ID, out e))
				((EntityEventHolder<E>)e).entityEvent(entity, args);
		}

		public void AddSystemEvent<E>(Action<E> callback) // Adds an Event Listener
		{
			object e;
			if (systemEventLookup.TryGetValue(EventID<E>.ID, out e))
			{
				((SystemEventHolder<E>)e).systemEvent += callback;
				return;
			}

			SystemEventHolder<E> newEvent = new SystemEventHolder<E>();
			newEvent.systemEvent += callback;

			systemEventLookup.Add(EventID<E>.ID, newEvent);
		}

		public void RemoveSystemEvent<E>(Action<E> callback)	// Removes Event Listener
		{
			object e;
			if (systemEventLookup.TryGetValue(EventID<E>.ID, out e))
			{	
				((SystemEventHolder<E>)e).systemEvent -= callback;
			}
		}

		public void CallSystemEvent<E>(E args)	// Calls Event with Arguments
		{
			object e;
			if (systemEventLookup.TryGetValue(EventID<E>.ID, out e))
				((SystemEventHolder<E>)e).systemEvent(args);
		}

		#endregion
	}
		 
	/// 
	/// 
	///		ENTITY MANAGER INSPECTOR
	///
	///

	#if UNITY_EDITOR

	public class EntitySystemInfo
	{
		public EntitySystem System;
		public bool ShowInfo;

		public List<Type> EntityEvents = new List<Type>();
		public bool showEntityEvents;

		public List<Type>AddGroupEvents = new List<Type>();
		public bool showAddGroupEvents;

		public List<Type>RemoveGroupEvents = new List<Type>();
		public bool showRemoveGroupEvents;

		public List<Type> SystemEvents = new List<Type>();
		public bool showSystemEvents;

		public bool isUpdateSystem;
		public bool isFixedUpdateSystem;

		public List<Type> UpdateTypes = new List<Type>();
		public bool showUpdate;

		public List<Type> FixedUpdateTypes = new List<Type>();
		public bool showFixedUpdate;

		public double UpdateTime;
		public double FixedUpdateTime;

		System.Diagnostics.Stopwatch timer = new global::System.Diagnostics.Stopwatch();

		public void StartUpdateTimer()
		{
			timer.Reset();
			timer.Start();
		}

		public void StopUpdateTimer()
		{
			timer.Stop();
			UpdateTime = timer.Elapsed.TotalMilliseconds;
		}

		public void StartFixedUpdateTimer()
		{
			timer.Reset();
			timer.Start();
		}

		public void StopFixedUpdateTimer()
		{
			timer.Stop();
			FixedUpdateTime = timer.Elapsed.TotalMilliseconds;
		}
	}

	[CustomEditor(typeof(EntityManager))]
	public class EntityManagerInspector : Editor
	{
		EntityManager manager;

		void OnEnable()
		{
			manager = (EntityManager)target;
		}

		public class SearchFilter
		{
			public SearchFilter(int order, EntitySystemInfo info)
			{
				this.order = order;
				this.info = info;
			}
			public int order;
			public EntitySystemInfo info;
		}

		List<SearchFilter> searchResults = new List<SearchFilter>();
		int searchIndex;

		enum SearchType
		{ 
			Name, UpdateSystemWithName, FixedUpdateSystemWithName, UpdateSystemWithComponent, FixedUpdateSystemWithComponent, EntityEvent, SystemEvent, EnableGroupEventWithComponent, DisableGroupEventWithComponent
		}

		SearchType searchtype = SearchType.Name;
		SearchType lastSearchType = SearchType.Name;
		string lastSearch = "";
		string currentSearch = "";
		bool refreshSearch;

		int DisplaySystemCount = 20;

		public override void OnInspectorGUI ()
		{
			if (Application.isPlaying)
			{
				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider, GUILayout.Width(Screen.width - 48f));
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(new GUIContent(string.Format("Entities : {0}", manager.totalEntityCount), "Total amount of instantiated Entities"), GUILayout.Width(Screen.width/2f - 24f));
				EditorGUILayout.LabelField(new GUIContent(string.Format("Groups : {0}", manager.groupLookup.Count), "Total amount of instantiated Groups"), GUILayout.Width(Screen.width/2f- 24f));
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(new GUIContent(string.Format("Systems : {0}", manager.SystemsInfo.Count), "Total amount of instantiated Systems"), GUILayout.Width(Screen.width/2f- 24f));
				EditorGUILayout.LabelField(new GUIContent(string.Format("Component Types : {0}", manager.componentIDLookup.Count), "Total amount of unique component types"), GUILayout.Width(Screen.width/2f- 24f));
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(new GUIContent(string.Format("Update : {0:F2} ms", manager.UpdateTime) , "Total time to update all Update Systems")  , GUILayout.Width(Screen.width/2f- 24f));
				EditorGUILayout.LabelField(new GUIContent(string.Format("Fixed Update : {0:F2} ms", manager.FixedUpdateTime), "Total time to update all Fixed Update Systems"), GUILayout.Width(Screen.width/2f- 24f));
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider, GUILayout.Width(Screen.width - 48f));

				currentSearch = EditorGUILayout.TextField (new GUIContent("Search Systems", "Perform filtering of Systems"), 
					currentSearch, GUILayout.MaxWidth(Screen.width - 48f));

				searchtype = (SearchType)EditorGUILayout.EnumPopup(new GUIContent("Search By", 
						"Define how you search for Systems.\n\nE.g Search for all Update Systems with name\n       Search for all Fixed Update Systems that implement component\n       Search for all systems that implement Entity Event"), 
					searchtype, GUILayout.MaxWidth(Screen.width - 48f));

				if (!string.IsNullOrEmpty(currentSearch))
				{
					currentSearch = currentSearch.Replace(" ", "");

					if (currentSearch != lastSearch || searchtype != lastSearchType || refreshSearch)
					{
						lastSearch = currentSearch;
						lastSearchType = searchtype;
						searchResults.Clear();


						switch(searchtype)
						{
						case SearchType.Name:
							SearchByName ();
							break;
						case SearchType.UpdateSystemWithName:
							SearchUpdateByName();
							break;
						case SearchType.FixedUpdateSystemWithName:
							SearchFixedUpdateByName();
							break;
						case SearchType.UpdateSystemWithComponent:
							SearchUpdateByComponent();
							break;
						case SearchType.FixedUpdateSystemWithComponent:
							SearchFixedUpdateByComponent();
							break;
						case SearchType.EntityEvent:
							SearchByEntityEvent();
							break;
						case SearchType.SystemEvent:
							SearchBySystemEvent();
							break;
						case SearchType.EnableGroupEventWithComponent:
							SearchEnableGroupByComponent();
							break;
						case SearchType.DisableGroupEventWithComponent:
							SearchDisableGroupByComponent();
							break;
						default:
							break;
						}
					}

					DrawPrevAndNextButtons(ref searchIndex, searchResults.Count);

					for(int i = searchIndex; i < Mathf.Min(searchResults.Count, searchIndex + DisplaySystemCount); ++i)
					{
						DrawSystemInfo(searchResults[i].order, searchResults[i].info);
					}
				}
				else DrawAllSystems();

				EditorUtility.SetDirty(target);

				var guiStyle = GUI.skin.GetStyle("HelpBox");
				EditorGUILayout.LabelField(GUI.tooltip, guiStyle, GUILayout.Height(64f), GUILayout.MaxWidth(Screen.width - 48f));
			}
			else
			{
				EditorGUILayout.HelpBox("SimpleECS Manager class, needs to be in scene for SimpleECS to work. Automatically sets itself to 'Don't Destroy on Load'. When transitioning to a new scene will automatically destroy any duplicate Entity Managers.", MessageType.Info); 
			}
		}

		void ListTypes(string name, string tooltip, List<Type> types, ref bool show)
		{
			show = EditorGUILayout.Foldout(show, new GUIContent(name, tooltip));
			if (!show)return;

			foreach(var type in types)
			{
				EditorGUILayout.LabelField(string.Format("| {0} ", type));	
			}
		}

		void DrawSystemInfo(int index, EntitySystemInfo info)
		{
			var defaultColor = GUI.color;
			var disabledColor = GUI.color;
			disabledColor.a = .5f;

			if (info == null || info.System == null)
			{
				refreshSearch = true;
				return;
			}

			if (!info.System.isActiveAndEnabled) GUI.color = disabledColor;

			EditorGUILayout.BeginHorizontal(EditorStyles.helpBox, GUILayout.Width(Screen.width - 48f));

			info.ShowInfo = EditorGUI.Foldout(GUILayoutUtility.GetRect(8f , 16f), info.ShowInfo, "");

			// var buttonStyle = new GUIStyle("label");
			//buttonStyle.contentOffset = new Vector2(0, -2f);

			var content = new GUIContent(string.Format("{0} : {1}", index, DisplayStringWithSpaces(info.System.GetType().ToString())), info.System.Tooltip());// "Execution Order and Name of System\nClick to Hightlight System in Heirachy"); 

			info.System.enabled = EditorGUILayout.Toggle(info.System.enabled);
			if (GUILayout.Button( content , GUI.skin.label, GUILayout.Width(Screen.width - 160f), GUILayout.Height(16f)))
			{
				EditorGUIUtility.PingObject(info.System);
			}

			if (info.isUpdateSystem || info.isFixedUpdateSystem)
				EditorGUILayout.LabelField(new GUIContent(string.Format("| {0:F2} ms", info.UpdateTime + info.FixedUpdateTime), "How long it system takes to complete all update and fixed updates"), GUILayout.MaxWidth(72f));
			else EditorGUILayout.LabelField("", GUILayout.MaxWidth(72f));

			EditorGUILayout.EndHorizontal();
			EditorGUI.indentLevel ++;
			if (info.ShowInfo)
			{
				if (info.isUpdateSystem)
					info.showUpdate = EditorGUILayout.Foldout(info.showUpdate, new GUIContent(string.Format("Update Groups: {0:F2} ms", info.UpdateTime), "List of all Groups currently updated by system and how long it takes to update"));
				if (info.showUpdate)
				{
					foreach(var type in info.UpdateTypes)
					{
						EditorGUILayout.LabelField(new GUIContent(string.Format("{0} Entities : {1}", manager.groupLookup[type].Count, type.ToString().Remove(0, 19)), "Entities Currently in Group and Group Type"));
					}
				}

				if (info.isFixedUpdateSystem)
					info.showFixedUpdate = EditorGUILayout.Foldout(info.showFixedUpdate, new GUIContent(string.Format("Fixed Update Groups: {0:F2} ms", info.FixedUpdateTime), "List of all Groups currently fixed updated by system and how long it takes to update"));
				if (info.showFixedUpdate)
				{
					foreach(var type in info.FixedUpdateTypes)
					{
						EditorGUILayout.LabelField(new GUIContent(string.Format("{0} Entities : {1}", manager.groupLookup[type].Count, type.ToString().Remove(0, 19)), "Entities Currently in Group and Group Type"));
					}
				}
				if (info.EntityEvents.Count > 0)
					info.showEntityEvents = EditorGUILayout.Foldout(info.showEntityEvents, new GUIContent("Entity Events", "List of Entity Event callbacks implemented by this system"));
				if (info.showEntityEvents)
				{
					foreach(var type in info.EntityEvents)
					{
						EditorGUILayout.LabelField(string.Format("{0}", type.ToString()));
					}
				}
				if (info.SystemEvents.Count > 0)
					info.showSystemEvents = EditorGUILayout.Foldout(info.showSystemEvents, new GUIContent("System Events", "List of System Event callbacks implement by this system"));
				if (info.showSystemEvents)
				{
					foreach(var type in info.SystemEvents)
					{
						EditorGUILayout.LabelField(string.Format("{0}", type.ToString()));
					}
				}
				if (info.AddGroupEvents.Count > 0)
					info.showAddGroupEvents = EditorGUILayout.Foldout(info.showAddGroupEvents, new GUIContent("Enable Group Events", "List of all add group events implemented by this system"));
				if (info.showAddGroupEvents)
				{
					foreach(var type in info.AddGroupEvents)
					{
						EditorGUILayout.LabelField(type.ToString().Remove(0,19));
					}
				}
				if (info.RemoveGroupEvents.Count > 0)
					info.showRemoveGroupEvents = EditorGUILayout.Foldout(info.showRemoveGroupEvents, new GUIContent("Disable Group Events", "List of all remove group events implemented by this system"));
				if (info.showRemoveGroupEvents)
				{
					foreach(var type in info.RemoveGroupEvents)
					{
						EditorGUILayout.LabelField(type.ToString().Remove(0,19));
					}
				}
			}

			EditorGUI.indentLevel --;
			GUI.color = defaultColor;
		}

		void DrawPrevAndNextButtons(ref int index, int systemCount)
		{
			EditorGUILayout.BeginHorizontal();

			if (systemCount >= DisplaySystemCount)
			{
				if (index >= DisplaySystemCount)
				{
					if (GUILayout.Button(string.Format("<- Previous {0}", DisplaySystemCount), GUILayout.MaxWidth(Screen.width/2f - 24f)))
						index -= DisplaySystemCount;

					if (index + DisplaySystemCount > systemCount)
					{
						GUI.enabled = false;
						GUILayout.Button(string.Format("Next {0} ->", DisplaySystemCount), GUILayout.MaxWidth(Screen.width/2f - 24f));
						GUI.enabled = true;
					}
				}
				if (index + DisplaySystemCount < systemCount)
				{
					if (index < DisplaySystemCount)
					{
						GUI.enabled = false;
						GUILayout.Button(string.Format("<- Previous {0}", DisplaySystemCount), GUILayout.MaxWidth(Screen.width/2f - 24f));
						GUI.enabled = true;
					}

					if (GUILayout.Button(string.Format("Next {0} ->", DisplaySystemCount), GUILayout.MaxWidth(Screen.width/2f - 24f)))
						index += DisplaySystemCount;
				}
			}
			EditorGUILayout.EndHorizontal();
		}

		string DisplayStringWithSpaces(string text)
		{
			if (string.IsNullOrEmpty(text)) return text;

			System.Text.StringBuilder newText = new System.Text.StringBuilder(text.Length*2);
			newText.Append(text[0]);
			for(int i = 1; i < text.Length; ++i)
			{
				if (char.IsUpper(text[i]) && (char.IsLower(text[i-1])))
				{
					newText.Append(" ");	
				}
				newText.Append(text[i]);
			}
			return newText.ToString();
		}

		void DrawAllSystems()
		{
			DrawPrevAndNextButtons(ref manager.SystemInfoIndex, manager.SystemsInfo.Count);

			for(int i = manager.SystemInfoIndex; i < Mathf.Min(manager.SystemsInfo.Count, manager.SystemInfoIndex + DisplaySystemCount); ++i)
			{
				DrawSystemInfo(i+1, manager.SystemsInfo[i]);
			}
		}


		void SearchByName()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				order ++;
				if (item.System.GetType().ToString().IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					searchResults.Add(new SearchFilter(order, item));
				}
			}
			searchIndex = 0;
		}

		void SearchUpdateByName()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				order ++;
				if (!item.isUpdateSystem) continue;

				if (item.System.GetType().ToString().IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					searchResults.Add(new SearchFilter(order, item));
				}
			}
			searchIndex = 0;


		}

		void SearchFixedUpdateByName()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				order ++;
				if (!item.isFixedUpdateSystem) continue;

				if (item.System.GetType().ToString().IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					searchResults.Add(new SearchFilter(order, item));
				}
			}
			searchIndex = 0;
		}

		void SearchUpdateByComponent()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				order ++;
				if (!item.isUpdateSystem) continue;

				foreach(var type in item.UpdateTypes)
				{
					if (type.ToString().Remove(0,19).IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >=0)
					{
						searchResults.Add(new SearchFilter(order, item));
						break;
					}
				}
			}
			searchIndex = 0;
		}
			
		void SearchFixedUpdateByComponent()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				order ++;
				if (!item.isFixedUpdateSystem) continue;

				foreach(var type in item.FixedUpdateTypes)
				{
					if (type.ToString().Remove(0,19).IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >=0)
					{
						searchResults.Add(new SearchFilter(order, item));
						break;
					}
				}
			}
			searchIndex = 0;
		}

		void SearchByEntityEvent()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				order ++;
				if (item.EntityEvents.Count == 0) continue;
				foreach(var type in item.EntityEvents)
				{
					if (type.ToString().IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >=0)
					{
						searchResults.Add(new SearchFilter(order, item));
						break;
					}
				}
			}
			searchIndex = 0;
		}

		void SearchBySystemEvent()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				order ++;
				if (item.SystemEvents.Count == 0) continue;
				foreach(var type in item.SystemEvents)
				{
					if (type.ToString().IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >=0)
					{
						searchResults.Add(new SearchFilter(order, item));
						break;
					}
				}
			}
			searchIndex = 0;
		}

		void SearchEnableGroupByComponent()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				order ++;
				if (item.AddGroupEvents.Count == 0) continue;
				foreach(var type in item.AddGroupEvents)
				{
					if (type.ToString().Remove(0,26).IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >=0)
					{
						searchResults.Add(new SearchFilter(order, item));
						break;
					}
				}
			}
			searchIndex = 0;
		}

		void SearchDisableGroupByComponent()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				order ++;
				if (item.RemoveGroupEvents.Count == 0) continue;
				foreach(var type in item.RemoveGroupEvents)
				{
					if (type.ToString().Remove(0,26).IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >=0)
					{
						searchResults.Add(new SearchFilter(order, item));
						break;
					}
				}
			}
			searchIndex = 0;
		}
	}
	#endif
}
