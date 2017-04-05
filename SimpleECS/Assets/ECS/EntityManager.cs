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
		public List<SystemInfo> SystemsInfo = new List<SystemInfo>();	// systems is added to by the system on awake
		public int SystemInfoIndex;
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
			UpdateCallback();	
		}

		void FixedUpdate()
		{
			FixedUpdateCallback();
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

	public class SystemInfo
	{
		public BaseEntitySystem System;
		public bool ShowInfo;
		public List<Type> ComponentPoolTypes = new List<Type>();

		public List<Type> EntityEvents = new List<Type>();
		public bool showEntityEvents;

		public List<Type> EnableComponentEvent = new List<Type>();
		public bool showEnableComponentEvent;

		public List<Type> DisableComponentEvent = new List<Type>();
		public bool showDisableComponentEvent;

		public List<Type> SystemEvents = new List<Type>();
		public bool showSystemEvents;

		public double UpdateTime;
		public double FixedUpdateTime;

		System.Diagnostics.Stopwatch timer = new global::System.Diagnostics.Stopwatch();
		System.Diagnostics.Stopwatch fixedTimer = new global::System.Diagnostics.Stopwatch();

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
			fixedTimer.Start();
		}

		public void StopFixedUpdateTimer()
		{
			fixedTimer.Stop();
			FixedUpdateTime = fixedTimer.Elapsed.TotalMilliseconds;
			fixedTimer.Reset();
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

		public override void OnInspectorGUI ()
		{
			if (Application.isPlaying)
			{
				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(string.Format("Entities : {0}", manager.totalEntityCount), GUILayout.MaxWidth(128f));
				EditorGUILayout.LabelField(string.Format("Groups : {0}", manager.groups.Count));
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(string.Format("Systems : {0}", manager.SystemsInfo.Count), GUILayout.MaxWidth(128f));
				EditorGUILayout.LabelField(string.Format("Component Types : {0}", manager.componentIDLookup.Count));
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

				EditorGUILayout.BeginHorizontal();
				if (manager.SystemsInfo.Count >= 25)
				{
					if (manager.SystemInfoIndex >= 25)
					{
						if (GUILayout.Button("<- Previous 25", GUILayout.MaxWidth(Screen.width/2f - 24f)))
							manager.SystemInfoIndex -= 25;

						if (manager.SystemInfoIndex + 25 > manager.SystemsInfo.Count)
						{
							GUI.enabled = false;
							GUILayout.Button("Next 25 ->", GUILayout.MaxWidth(Screen.width/2f - 24f));
							GUI.enabled = true;
						}
					}
					if (manager.SystemInfoIndex + 25 < manager.SystemsInfo.Count)
					{
						if (manager.SystemInfoIndex < 25)
						{
							GUI.enabled = false;
							GUILayout.Button("<- Previous 25", GUILayout.MaxWidth(Screen.width/2f - 24f));
							GUI.enabled = true;
						}

						if (GUILayout.Button("Next 25 ->", GUILayout.MaxWidth(Screen.width/2f - 24f)))
							manager.SystemInfoIndex += 25;
					}
				}
				EditorGUILayout.EndHorizontal();

				for (int i = manager.SystemInfoIndex ; i < Mathf.Min(manager.SystemsInfo.Count, manager.SystemInfoIndex + 25); ++i)
				{
					var info = manager.SystemsInfo[i];

					EditorGUILayout.BeginHorizontal();
					info.ShowInfo = EditorGUI.Foldout(GUILayoutUtility.GetRect(8f , 16f), info.ShowInfo, "");

					EditorGUI.LabelField(GUILayoutUtility.GetRect(Screen.width - 129f - 32f, 16f), string.Format("{0} : {1}", i, info.System.GetType()));

					if (info.System.isActiveAndEnabled)
					{
						if (info.System is IEntityCount)
							EditorGUILayout.LabelField(string.Format("| {0} Entities", (info.System as IEntityCount).GetEntityCount()), GUILayout.MaxWidth(128f));
						else
							EditorGUILayout.LabelField("", GUILayout.MaxWidth(128f));
					}
					else
					{
						EditorGUILayout.LabelField("| Disabled" , GUILayout.MaxWidth(128f));
					}
					EditorGUILayout.EndHorizontal();

					if (info.ShowInfo)
					{
						EditorGUI.indentLevel += 2;
						if (info.ComponentPoolTypes.Count > 0)
						{
							string pool = ":";
							foreach(var types in info.ComponentPoolTypes)
							{
								pool += string.Format(" {0} :", types.ToString());
							}
							EditorGUILayout.LabelField(pool);
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
							info.showEntityEvents = EditorGUILayout.Foldout(info.showEntityEvents, String.Format("EntityEvents : {0}", info.EntityEvents.Count));
							if (info.showEntityEvents)
							{
								ListTypes(info.EntityEvents);
							}
							EditorGUI.indentLevel --;
						}

						if (info.EnableComponentEvent.Count > 0)
						{
							EditorGUI.indentLevel ++;
							info.showEnableComponentEvent = EditorGUILayout.Foldout(info.showEnableComponentEvent, string.Format("Enable Component Events : {0}", info.EnableComponentEvent.Count));
							if (info.showEnableComponentEvent)
							{
								ListTypes(info.EnableComponentEvent);
							}
							EditorGUI.indentLevel --;
						}

						if (info.DisableComponentEvent.Count > 0)
						{
							EditorGUI.indentLevel ++;
							info.showDisableComponentEvent = EditorGUILayout.Foldout(info.showDisableComponentEvent, string.Format("Disable Component Events : {0}", info.DisableComponentEvent.Count));
							if (info.showDisableComponentEvent)
							{
								ListTypes(info.DisableComponentEvent);
							}
							EditorGUI.indentLevel --;
						}

						EditorGUI.indentLevel -= 2;
					}
				}
				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
				EditorUtility.SetDirty(target);
			}
			else
			{
				EditorGUILayout.HelpBox("SimpleECS Manager class, needs to be in scene for SimpleECS to work. Automatically sets itself to 'Don't Destroy on Load'. When transitioning to a new scene will automatically destroy any duplicate Entity Managers.", MessageType.Info); 
			}
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
}
#endif

}