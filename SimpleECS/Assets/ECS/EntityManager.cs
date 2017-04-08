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
		public List<SystemsInfo> SystemsInfo = new List<SystemsInfo>();	// systems is added to by the system on awake
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

		public Stack<Group> groups = new Stack<Group>(); 			// Keeps track of all groups so I can clear them out when not needed

		public Group<C> GetGroup<C>() where C : EntityComponent<C>	// Returns an instance of a group, gets called during Group Instantiation
		{
			Group<C> newGroup = new Group<C>(GetEntityComponentID<C>());
			groups.Push(newGroup);
			return newGroup;
		}

		public Group<C1, C2> GetGroup<C1, C2>() 
			where C1 : EntityComponent<C1>
			where C2 : EntityComponent<C2>
		{
			Group<C1, C2> newGroup = new Group<C1,C2>();
			groups.Push(newGroup);
			return newGroup;
		}

		public Group<C1, C2, C3> GetGroup<C1, C2, C3>() 
			where C1 : EntityComponent<C1>
			where C2 : EntityComponent<C2>
			where C3 : EntityComponent<C3>
		{
			Group<C1, C2, C3> newGroup = new Group<C1,C2,C3>();
			groups.Push(newGroup);
			return newGroup;
		}

		public Group<C1, C2, C3, C4> GetGroup<C1, C2, C3, C4>() 
			where C1 : EntityComponent<C1>
			where C2 : EntityComponent<C2>
			where C3 : EntityComponent<C3>
			where C4 : EntityComponent<C4>
		{
			Group<C1, C2, C3, C4> newGroup = new Group<C1,C2,C3,C4>();
			groups.Push(newGroup);
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
			groups.Push(newGroup);
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

	public class SystemsInfo
	{
		public BaseEntitySystem System;
		public bool ShowInfo;
		public bool ShowFps;
		public Type Group = null;

		public List<Type> EntityEvents = new List<Type>();
		public bool showEntityEvents;

		public int AddGroupEvent = 0;
		public int RemoveGroupEvent = 0;

		public List<Type> SystemEvents = new List<Type>();
		public bool showSystemEvents;

		public double UpdateTime;
		public double FixedUpdateTime;

		System.Diagnostics.Stopwatch timer = new global::System.Diagnostics.Stopwatch();

		public void StartUpdateTimer()
		{
			timer.Start();
		}

		public void StopUpdateTimer()
		{
			timer.Stop();
			UpdateTime = timer.Elapsed.TotalMilliseconds;
			timer.Reset();
		}

		public void StartFixedUpdateTimer()
		{
			timer.Start();
		}

		public void StopFixedUpdateTimer()
		{
			timer.Stop();
			FixedUpdateTime = timer.Elapsed.TotalMilliseconds;
			timer.Reset();
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

		void OnDisable()
		{
			foreach(var info in manager.SystemsInfo)
			{
				info.ShowFps = false;
			}
		}

		string lastSearch = "";
		string currentSearch = "";

		public class SearchFilter
		{
			public SearchFilter(int order, SystemsInfo info)
			{
				this.order = order;
				this.info = info;
			}
			public int order;
			public SystemsInfo info;
		}

		List<SearchFilter> searchResults = new List<SearchFilter>();
		int searchIndex;


		enum SearchType
		{ 
			Name, Update, FixedUpdate, Component  
		}

		SearchType searchtype = SearchType.Name;
		SearchType lastSearchType = SearchType.Name;
		bool refreshSearch;

		public override void OnInspectorGUI ()
		{
			if (Application.isPlaying)
			{
				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(new GUIContent(string.Format("Entities : {0}", manager.totalEntityCount), "Total amount of instantiated Entities"),GUILayout.MaxWidth(128f));
				EditorGUILayout.LabelField(new GUIContent(string.Format("Groups : {0}", manager.groups.Count), "Total amount of instantiated Groups"));
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(new GUIContent(string.Format("Systems : {0}", manager.SystemsInfo.Count), "Total amount of instantiated Systems"), GUILayout.MaxWidth(128f));
				EditorGUILayout.LabelField(new GUIContent(string.Format("Component Types : {0}", manager.componentIDLookup.Count), "Total amount of unique component types"));
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(new GUIContent(string.Format("Update : {0:F2} ms", manager.UpdateTime) , "Total time to update all Update Systems")  , GUILayout.MaxWidth(128f));
				EditorGUILayout.LabelField(new GUIContent(string.Format("Fixed Update : {0:F2} ms", manager.FixedUpdateTime), "Total time to update all Fixed Update Systems"));
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);


				currentSearch = EditorGUILayout.TextField (new GUIContent("Search Systems", "Perform filtering of Systems"), currentSearch);
				searchtype = (SearchType)EditorGUILayout.EnumPopup(new GUIContent("Search Type", 
						"Name : Search by Name \nUpdate : Search update systems by name \nFixedUpdate : Search Fixed Update systems by name \nComponent : Search by systems by component type"), searchtype);

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
							NameSearch();
							break;
						case SearchType.Update:
							UpdateSearch();
							break;
						case SearchType.FixedUpdate:
							FixedSearch();
							break;
						case SearchType.Component:
							ComponentSearch();
							break;
						default: 
							NameSearch();
							break;
						}
					}

					DrawPrevAndNextButtons(ref searchIndex, searchResults.Count);

					for(int i = searchIndex; i < Mathf.Min(searchResults.Count, searchIndex + 25); ++i)
					{
						DisplaySystemInfo(searchResults[i].order, searchResults[i].info);
					}
				}
				else DrawAllSystems();

				EditorUtility.SetDirty(target);

				var guiStyle = GUI.skin.GetStyle("HelpBox");

				EditorGUILayout.LabelField(GUI.tooltip, guiStyle, GUILayout.Height(64f));
			}
			else
			{
				EditorGUILayout.HelpBox("SimpleECS Manager class, needs to be in scene for SimpleECS to work. Automatically sets itself to 'Don't Destroy on Load'. When transitioning to a new scene will automatically destroy any duplicate Entity Managers.", MessageType.Info); 
			}
		}

		void NameSearch()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				if (item.System.GetType().ToString().IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					searchResults.Add(new SearchFilter(order, item));
				}
				order ++;
			}
			searchIndex = 0;
		}

		void UpdateSearch()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				if (item.System is UpdateSystem)
				{
					if (item.System.GetType().ToString().IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >= 0)
					{
						searchResults.Add(new SearchFilter(order, item));
					}	
				}
				order ++;
			}
			searchIndex = 0;
		}

		void FixedSearch()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				if (item.System is FixedUpdateSystem)
				{
					if (item.System.GetType().ToString().IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >= 0)
					{
						searchResults.Add(new SearchFilter(order, item));
					}	
				}
				order ++;
			}
			searchIndex = 0;
		}

		void ComponentSearch()
		{
			int order = 0;
			foreach(var item in manager.SystemsInfo)
			{
				if (item.Group == null) continue;
				if (item.Group.ToString().IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					searchResults.Add(new SearchFilter(order, item));
				}	
				order ++;
			}
			searchIndex = 0;
		}

		void ListTypes(List<Type> types)
		{
			//EditorGUI.indentLevel ++;
			foreach(var type in types)
			{
				EditorGUILayout.LabelField(string.Format("| {0}", type.ToString()));	
			}
			//EditorGUI.indentLevel --;
		}

		void DrawPrevAndNextButtons(ref int index, int systemCount)
		{
			EditorGUILayout.BeginHorizontal();

			if (systemCount >= 25)
			{
				if (index >= 25)
				{
					if (GUILayout.Button("<- Previous 25", GUILayout.MaxWidth(Screen.width/2f - 24f)))
						index -= 25;

					if (index + 25 > systemCount)
					{
						GUI.enabled = false;
						GUILayout.Button("Next 25 ->", GUILayout.MaxWidth(Screen.width/2f - 24f));
						GUI.enabled = true;
					}
				}
				if (index + 25 < systemCount)
				{
					if (index < 25)
					{
						GUI.enabled = false;
						GUILayout.Button("<- Previous 25", GUILayout.MaxWidth(Screen.width/2f - 24f));
						GUI.enabled = true;
					}

					if (GUILayout.Button("Next 25 ->", GUILayout.MaxWidth(Screen.width/2f - 24f)))
						index += 25;
				}
			}
			EditorGUILayout.EndHorizontal();
		}

		void DrawAllSystems()
		{
			DrawPrevAndNextButtons(ref manager.SystemInfoIndex, manager.SystemsInfo.Count);

			for(int i = manager.SystemInfoIndex ; i < Mathf.Min(manager.SystemInfoIndex + 25, manager.SystemsInfo.Count); ++i)
			{
				DisplaySystemInfo(i, manager.SystemsInfo[i]);
			}
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
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


		void DisplaySystemInfo(int order, SystemsInfo info)
		{
			if (info == null || info.System == null)
			{
				refreshSearch = true;
				return;
			}

			info.ShowFps = true;
			if (!info.System.isActiveAndEnabled)
			{
				info.ShowFps = false;
				GUI.enabled = false;
			}

			EditorGUILayout.BeginHorizontal(EditorStyles.helpBox, GUILayout.Width(Screen.width - 48f));
			info.ShowInfo = EditorGUI.Foldout(GUILayoutUtility.GetRect(8f , 16f), info.ShowInfo, "");

			var buttonStyle = new GUIStyle("label");
			//buttonStyle.contentOffset = new Vector2(0, -2f);

			var content = new GUIContent(string.Format("{0} : {1}", order, DisplayStringWithSpaces(info.System.GetType().ToString())), "Execution Order and Name of System\nClick to Hightlight System in Heirachy"); 

			if (GUILayout.Button( content, buttonStyle , GUILayout.Width(Screen.width - 200f), GUILayout.Height(16f)))
			{
				EditorGUIUtility.PingObject(info.System);
			}


			if (info.System.isActiveAndEnabled)
			{
				if (info.System is IEntityCount)
					EditorGUILayout.LabelField(new GUIContent(string.Format("| {0} Entities", (info.System as IEntityCount).GetEntityCount()), "Entities currently using this system"), GUILayout.MaxWidth(84f));
				else
					EditorGUILayout.LabelField("", GUILayout.MaxWidth(84f));

				double updateTime = 0;
				if (info.ShowFps &&(info.System is UpdateSystem || info.System is FixedUpdateSystem))
				{
					updateTime += info.UpdateTime;
					updateTime += info.FixedUpdateTime;

					EditorGUILayout.LabelField(new GUIContent(string.Format("| {0:F2} ms", updateTime), "Total time to update system"), GUILayout.MaxWidth(84f));
				}
				else EditorGUILayout.LabelField("", GUILayout.MaxWidth(84f));
			}
			else
			{
				EditorGUILayout.LabelField("| Disabled" , GUILayout.MaxWidth(84f+32f+84f));
			}
			EditorGUILayout.EndHorizontal();

			if (info.ShowInfo)
			{
				EditorGUI.indentLevel += 2;
				if (info.Group != null)
				{
					EditorGUILayout.LabelField(info.Group.ToString().Remove(0,19));
				}

				if (info.System is UpdateSystem)
				{
					EditorGUILayout.LabelField (string.Format("Update System : {0:F2} ms", info.UpdateTime));
				}

				if (info.System is FixedUpdateSystem)
				{
					EditorGUILayout.LabelField (string.Format("Fixed Update System : {0:F2} ms", info.FixedUpdateTime));
				}

				if (info.SystemEvents.Count > 0)
				{
					EditorGUI.indentLevel ++;
					info.showSystemEvents = EditorGUILayout.Foldout(info.showSystemEvents, string.Format("System Events : {0}", info.SystemEvents.Count));
					if (info.showSystemEvents)
					{
						ListTypes(info.SystemEvents);
					}
					EditorGUI.indentLevel --;
				}

				if (info.EntityEvents.Count > 0)
				{
					EditorGUI.indentLevel ++;
					info.showEntityEvents = EditorGUILayout.Foldout(info.showEntityEvents, String.Format("Entity Events : {0}", info.EntityEvents.Count));
					if (info.showEntityEvents)
					{
						ListTypes(info.EntityEvents);
					}
					EditorGUI.indentLevel --;
				}

				if (info.AddGroupEvent > 0)
				{
					EditorGUI.indentLevel ++;
					EditorGUILayout.LabelField(string.Format("Add Group Events : {0}", info.AddGroupEvent));
					EditorGUI.indentLevel --;
				}

				if (info.RemoveGroupEvent > 0)
				{
					EditorGUI.indentLevel ++;
					EditorGUILayout.LabelField(string.Format("Remove Group Events : {0}", info.AddGroupEvent));
					EditorGUI.indentLevel --;
				}

				EditorGUI.indentLevel -= 2;
			}

			GUI.enabled = true;
		}
	}
}
#endif

