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
		}

		//
		//	PROPERTIES
		//


		// reference to all component ID's
		static Dictionary<Type, int> _componentTypes = new Dictionary<Type, int>();
		public static Dictionary<int , ComponentPool> _componentLookUPs = new Dictionary<int, ComponentPool>();
		static List<Type> _componentTypeIndex = new List <Type>();
		static Stack<Entity> _pooledEntities = new Stack<Entity>();
		static HashSet<Entity> _activeEntities = new HashSet<Entity>();
		static List<Entity> _entities = new List<Entity>();		// List of all current entities

		public static ComponentPool GetComponentPool(int ID)
		{
			ComponentPool pool;
			if (_componentLookUPs.TryGetValue(ID, out pool))
			{
				return pool;
			}
			return null;
		}

		public static HashSet<Entity> ActiveEntities
		{
			get {return _activeEntities;}
		}

		//
		// METHODS
		//
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
			return _pooledEntities.Count + _activeEntities.Count;
		}

		public static int GetTotalUniqueComponetTypes()
		{
			return _componentTypeIndex.Count;
		}

		/// <summary>
		/// Returns component type at component ID
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
		public static int GetComponentID<C>() where C: EntityComponent, new()
		{
			int id = -1;
			if (_componentTypes.TryGetValue(typeof(C), out id))
			{
				id = _componentTypes[typeof(C)];
			}
			return id;
		}

		public static Entity GetEntity(int ID)						// returns entity with ID
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
				e = _pooledEntities.Pop();
			}
			else
			{
				e = new Entity(_entities.Count);
				e._SetComponentIndexSize(_componentTypes.Count);
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
				_pooledEntities.Push(e);

				for(int i=0; i < _componentTypes.Count; ++i)
				{
					if (e.Has(i))
					{
						GetComponentPool(i).BaseRemoveComponent(e);
					}
				}
			}
		}

		// GROUPS
		public static Dictionary<Type, Groups> _groups = new Dictionary<Type, Groups>();

	}




}


