using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace ECS.Internal
{
	public static class EntityPool
	{
		//
		// CONSTRUCTOR
		//
		static EntityPool()
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();	// Get a list of all IComponents
			foreach(var assembly in assemblies)
			{
				Type[] types = assembly.GetTypes();
				foreach( Type type in types)
				{
					if (type.IsSubclassOf(typeof(EntityComponent)))
					{
						_componentTypes.Add(type, _componentTypes.Count);
						_componentTypeIndex.Add(type);
					}
				}
			}
			_componentLookUPs = new ComponentPool[_componentTypes.Count];
		}

		//
		//	PROPERTIES
		//


		// Entity component index lookup
		public static List<short[]> EntityLookup = new List<short[]>();	// short to save some space, max 16000 ish components

		// reference to obtain component ID's by type
		static Dictionary<Type, int> _componentTypes = new Dictionary<Type, int>();

		// fast lookups to component pools by index, used by destory method
		public static ComponentPool[] _componentLookUPs;

		// fast lookup to component type by index
		static List<Type> _componentTypeIndex = new List <Type>();

		// entity pool
		static Queue<Entity> _pooledEntities = new Queue<Entity>();

		// Keeps track of all active entities
		static HashSet<Entity> _activeEntities = new HashSet<Entity>();

		// list of all entities, used to fetch Entities by ID
		static List<Entity> _entities = new List<Entity>();		// List of all current entities

		// Reference to get group by type
		public static Dictionary<Type, Groups> _groups = new Dictionary<Type, Groups>();

		//
		// METHODS & GETTERS
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
			return _componentTypeIndex.Count;
		}

		/// <summary>
		/// Returns component type with component ID
		/// </summary>
		public static Type GetComponentType (int ID)
		{
			if (ID < 0 || ID > _componentTypeIndex.Count)
				return null;
			return _componentTypeIndex[ID];
		}

		/// <summary>
		/// Returns Component ID of Component
		/// </summary>
		public static int GetComponentID<C>() where C: EntityComponent
		{
			int id = -1;
			if (_componentTypes.TryGetValue(typeof(C), out id))
			{
				id = _componentTypes[typeof(C)];
			}
			return id;
		}

		public static Entity GetEntity(int ID)	// returns entity with ID
		{
			if (ID < 0 || ID >= _entities.Count)
				return null;
			return (_entities[ID]);
		}

		public static Entity CreateEntity()
		{
			Entity e;
			if (_pooledEntities.Count > 0)
			{
				e = _pooledEntities.Dequeue();
			}
			else
			{
				e = new Entity(EntityLookup.Count);
				//e._SetComponentIndexSize(_componentTypes.Count);
				EntityLookup.Add(new short[_componentTypes.Count]);
				for (int i = 0; i < _componentTypes.Count; ++i)
				{
					EntityLookup[e.ID][i] = -1;	// set all components to 0
				}
			}
			_entities.Add(e);
			_activeEntities.Add(e);
			return e;
		}

		// EVENTS

		public static void DestroyEntity(Entity e)
		{
			if (_activeEntities.Contains(e))
			{
				_activeEntities.Remove(e);
				_pooledEntities.Enqueue(e);

				for(int i=0; i < _componentTypes.Count; ++i)
				{
					if (EntityLookup[e.ID][i] > -1)
					{
						_componentLookUPs[i].BaseRemoveComponent(e);	// remove component
						//EntityLookup[e.ID][i] = -1;					// set lookup value
					}
				}
			}
		}
	}




}


