using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace ECS.Internal
{
	// Keeps track of ECS Collections and handles spawning entites
	public static class ECSManager
	{
		//
		//
		// CONSTRUCTOR
		//
		//
		static ECSManager()
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();	// Get a list of all IComponents
			foreach(var assembly in assemblies)
			{
				Type[] types = assembly.GetTypes();
				foreach( Type type in types)
				{
					if (type.IsSubclassOf(typeof(EntityComponent)))
					{
						_componentIDbyType.Add(type, _componentIDbyType.Count);
						_componentTypeByIndex.Add(type);
					}
				}
			}
			_componentPoolByID = new ComponentPool[_componentIDbyType.Count];
		
			LoadSceneEvent += OnLoadScene;
		}

		//
		//
		//	PROPERTIES
		//
		//

		// Entity component index lookup
		public static List<ushort[]> EntityComponentIndexLookup = new List<ushort[]>();	// short to save some space, max 53k ish components

		// reference to obtain component ID's by type
		static Dictionary<Type, int> _componentIDbyType = new Dictionary<Type, int>();

		// fast lookups to component pools by index, used by destory method
		public static ComponentPool[] _componentPoolByID;

		// fast lookup to component type by index
		static List<Type> _componentTypeByIndex = new List <Type>();

		// entity pool
		static Queue<Entity> _pooledEntities = new Queue<Entity>();

		// Keeps track of all active entities // TODO list might be better, must experiment
		static HashSet<Entity> _activeEntities = new HashSet<Entity>();

		// list of all entities, used to fetch Entities by ID
		static List<Entity> _entities = new List<Entity>();		// List of all current entities

		// Reference to get group by type
		public static Dictionary<Type, Groups> _groupsByType = new Dictionary<Type, Groups>();

		public static int componentPoolCount = 0;

		//
		//
		// METHODS & GETTERS
		//
		//

		public static HashSet<Entity> ActiveEntities
		{
			get {return _activeEntities;}
		}
			
		public static int PooledEntitiesCount()
		{
			return _pooledEntities.Count;

		}
		public static int ActiveEntitiesCount()
		{
			return _activeEntities.Count;
		}

		public static int TotalEntitiesCount()
		{
			return _entities.Count;
		}

		public static int UniqueComponentCount()
		{
			return _componentTypeByIndex.Count;
		}
			
		public static Type GetComponentType (int ID)	/// Returns component type with component ID
		{
			if (ID < 0 || ID > _componentTypeByIndex.Count)
				return null;
			return _componentTypeByIndex[ID];
		}

		public static int GetComponentID<C>() where C: EntityComponent	/// Returns Component ID of Component
		{
			int id = -1;
			if (_componentIDbyType.TryGetValue(typeof(C), out id))
			{
				id = _componentIDbyType[typeof(C)];
			}
			return id;
		}

		public static Entity GetEntity(int ID)	// returns entity with ID
		{
			if (ID < 0 || ID >= _entities.Count)
				return null;
			return (_entities[ID]);
		}

		public static Entity CreateEntity()	// makes a new entity
		{
			//Debug.Log("Created Entity");
			Entity e;
			if (_pooledEntities.Count > 0)
			{
				e = _pooledEntities.Dequeue();
			}
			else
			{
				e = new Entity(EntityComponentIndexLookup.Count);
				EntityComponentIndexLookup.Add(new ushort[_componentIDbyType.Count]);
			}
			_entities.Add(e);
			_activeEntities.Add(e);
			return e;
		}

		//
		//
		// EVENTS
		//
		//

		public static Action LoadSceneEvent;

		public static void DestroyEntity(Entity e)	// removes all entities components and marks it available for reuse
		{
			if (_activeEntities.Contains(e))
			{
				_activeEntities.Remove(e);
				_pooledEntities.Enqueue(e);

				for(int i=0; i < _componentIDbyType.Count; ++i)
				{
					if (EntityComponentIndexLookup[e.ID][i] > 0)
					{
						_componentPoolByID[i].BaseRemoveComponent(e);	// remove component
					}
				}
			}
		}

		public static void OnLoadScene()
		{
			_groupsByType.Clear();

			foreach(ComponentPool pool in _componentPoolByID)
			{
				if (pool != null)
					pool.ClearPools();
			}

			EntityComponentIndexLookup.Clear();
			ActiveEntities.Clear();
			_pooledEntities.Clear();
			_entities.Clear();
			componentPoolCount = 0;
		}

	}
}


