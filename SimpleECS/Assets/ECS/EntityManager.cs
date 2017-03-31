using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public interface IUpdate{};
public interface IFixedUpdate{};

namespace SimpleECS.Internal	// putting it in this name space to clean up Intellisense and hide unnecessary classes
{
	public delegate void EntityEvent<E>(Entity sender, Entity reciever, E args);

	public sealed class EntityManager : MonoBehaviour
	{
		public static EntityManager instance; 	// yes it's singleton pattern

		public bool dontDestroyOnLoad = true;

		[HideInInspector]
		public int totalEntityCount; 	// this and the systems list below are only used for the custom inspector nothing else
		[HideInInspector]				// entity count is updated by the entity on awake
		public List<BaseEntitySystem> Systems = new List<BaseEntitySystem>();	// systems is added to by the system on awake

		int ComponentCount = -1; 	// Cache of how many components are in the Assembly
		Dictionary<System.Type, int> componentIDLookup = new Dictionary<System.Type, int>();	// Lookup table for component ID's
		Dictionary<Type, Group> groupLookup = new Dictionary<Type, Group>(); 					// Lookup table for Groups, stored here so they are cleaned up with this class on destroy
		Dictionary<int , object> entityEventLookup = new Dictionary<int, object>();				// Lookup table for Events, same reason as above

		public Action UpdateCallback = delegate {};			// this is the actual update callback, Systems just register thier Update calls to this
		public Action FixedUpdateCallback = delegate {};	// same as above except with fixed update

		bool reg;		// flag to notify that this is the Entity Manager being used, stops the Destroy function being called if that's not the case
		void Awake()
		{
			if (instance == null)	// singleton pattern, thought about using lazy load, but had to write too much boiler plate and decided this was simpler
			{
				reg = true;
				instance = this;
				if (dontDestroyOnLoad)		// besides this becomes less elegant with lazy load
					DontDestroyOnLoad(this);
			}
			else DestroyImmediate(this);
		}

		void Update()
		{
			UpdateCallback();	
		}

		void FixedUpdate()
		{
			FixedUpdateCallback();
		}

		int id; // this value is only used here
		public int GetID	// small simple function to doll out Entity ID's
		{
			get {return ++id;}
		}

		public int GetComponentCount()	// Returns Total amount of Entity Components in Assembly
		{
			if (ComponentCount == -1)	
			{
				var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();	// populates component IDs while it's at it, this probably should go in it's own method but I'll leave if for now
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
			return ComponentCount;
		}

		public int GetEntityComponentID<C>() // Retrieve Component ID's from lookup	
		{
			int id;
			if (componentIDLookup.TryGetValue(typeof(C), out id))
				return id;
			return -1;
		}

		public Group<C> GetGroup<C>() where C : EntityComponent<C>	// Returns an instance of a group
		{
			Group g;
			if (groupLookup.TryGetValue(typeof(C), out g))	// looking back at this I could just Instantiate them and dump them in a list since this function only gets called once
				return (Group<C>)g;

			Group<C> newG = new Group<C>(GetEntityComponentID<C>());
			groupLookup.Add(typeof(C), newG);
			return newG;
		}

		void OnDestroy()	// clean up all entity components to avoid mass null exceptions clogging up the inspector
		{
			if (!reg) return;	// only if it's been registered

			UpdateCallback = null;	// clear out delegates to avoid keeping references alive
			FixedUpdateCallback = null;

			var Entities = FindObjectsOfType<Entity>();
			var EntitySystems = FindObjectsOfType<EntitySystem>();

			foreach (var entity in Entities)
			{
				DestroyImmediate(entity);
			}
			foreach (var system in EntitySystems)
			{
				DestroyImmediate(system);
			}
		}

		/// <summary>
		/// Entity Events
		/// </summary>

		public class EventHolder<E>	// helper class to store Event delegates
		{
			public EntityEvent<E> entityEvent = delegate{};
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

		public void AddEvent<E>(EntityEvent<E> callback) // Adds an Event Listener
		{
			object e;
			if (entityEventLookup.TryGetValue(EventID<E>.ID, out e))
			{
				((EventHolder<E>)e).entityEvent += callback;
				return;
			}

			EventHolder<E> newEvent = new EventHolder<E>();
			newEvent.entityEvent += callback;

			entityEventLookup.Add(EventID<E>.ID, newEvent);
		}

		public void RemoveEvent<E>(EntityEvent<E> callback)	// Removes Event Listener
		{
			object e;
			if (entityEventLookup.TryGetValue(EventID<E>.ID, out e))
			{	
				((EventHolder<E>)e).entityEvent -= callback;
			}
		}

		public void InvokeEvent<E>(Entity sender, Entity reciever, E args)	// Calls Event with Arguments
		{
			object e;
			if (entityEventLookup.TryGetValue(EventID<E>.ID, out e))
				((EventHolder<E>)e).entityEvent(sender, reciever, args);
		}
	}





	public class Group{}
	public class Group<C>: Group where C : EntityComponent<C>
	{
		public Group(int ID)
		{
			this.ID = ID;
		}

		static Group<C> _i;
		public static Group<C> instance	// Yes this is singleton pattern. Fastest way I could find to get Component IDs
		{
			get 
			{
				if (_i == null)
				{
					_i = EntityManager.instance.GetGroup<C>();	// Instances are actually created by Entity Manager and dies with it
				}
				return _i;
			}
		}

		public List<C> componentList = new List<C>();	// current list of all enabled components of type

		public System.Action<Entity> EnabledComponentCallback = delegate {};	// gets called when a component is enabled
		public System.Action<Entity> DisabledComponentCallback = delegate {};	// gets called when a component is disabled

		public void EnableComponet(C c)	// Called by the component when enabled
		{
			componentList.Add(c);
			EnabledComponentCallback(c.entity);		// using entity instead of components otherwise I'd have to write methods for each component in the System instead of just one for the entity
		}											// using Components saves me only 1 has and get operation so it's not worth it

		public void RemoveComponent(C c)
		{
			componentList.Remove(c);	// as far as I'm aware removing from a list is a O(n) operation but using a Hashset means slow iteration loops. Maybe I'll use arrays in the future
			DisabledComponentCallback(c.entity);
		}

		public int ID;	// this makes it trivial to find the Component ID's
	}





	#if UNITY_EDITOR
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
				EditorGUILayout.TextArea("", GUI.skin.horizontalSlider);

				EditorGUILayout.LabelField(string.Format("Total Entities : {0}", manager.totalEntityCount));

				EditorGUILayout.TextArea("", GUI.skin.horizontalSlider);
				int count = 1;
				foreach(var system in manager.Systems)
				{
					if (system is IEntityCount)
					{
						if (system.enabled && system.gameObject.activeInHierarchy)
						{
							EditorGUILayout.BeginHorizontal();
								int eCount = (system as IEntityCount).GetEntityCount();
								EditorGUILayout.LabelField(string.Format("{0} : {1}", count, system.GetType()));
								EditorGUILayout.LabelField(string.Format("| {0} Entities", eCount), GUILayout.MaxWidth(128f));
							EditorGUILayout.EndHorizontal();
						}
						else
						{
							EditorGUILayout.BeginHorizontal();
								EditorGUILayout.LabelField(string.Format("{0} : {1}", count, system.GetType()));
								EditorGUILayout.LabelField("| Disabled" , GUILayout.MaxWidth(128f));
							EditorGUILayout.EndHorizontal();
						}
					}
					else
					{
						if (system.enabled && system.gameObject.activeInHierarchy)
						{
							EditorGUILayout.LabelField(string.Format("{0} : {1}", count, system.GetType()));	
						}
						else
						{
							EditorGUILayout.BeginHorizontal();
							EditorGUILayout.LabelField(string.Format("{0} : {1}", count, system.GetType()));
							EditorGUILayout.LabelField("| Disabled" , GUILayout.MaxWidth(128f));
							EditorGUILayout.EndHorizontal();	
						}
					}
					count ++;
				}
				EditorGUILayout.TextArea("", GUI.skin.horizontalSlider);
				EditorUtility.SetDirty(target);
			}
			else
			{
				DrawDefaultInspector();
			}
		}

		string GetEnabled(BaseEntitySystem system)
		{
			if (system.enabled && system.gameObject.activeInHierarchy)
			{
				return "Enabled";	
			}
			return "Disabled";
		}

}
#endif

}