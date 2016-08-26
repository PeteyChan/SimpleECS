using UnityEngine;
using System.Collections.Generic;
using System;
using ECS.Internal;
using System.Linq;

namespace ECS
{
	/// <summary>
	/// Group of entites that contain both Components
	/// </summary>
	public class Group<C1, C2>: Groups 
		where C1: EntityComponent
		where C2: EntityComponent
	{
		public Group()
		{
			// get component IDs
			C1_ID = ComponentPool<C1>.ID;
			C2_ID = ComponentPool<C2>.ID;

			// get components list
			c1_components = ComponentPool<C1>.GetComponentList();
			c2_components = ComponentPool<C2>.GetComponentList();

			_activeEntities = ComponentPool<C1>.ActiveEntities.
				Intersect(ComponentPool<C2>.ActiveEntities).ToList();

			// listen for changes to components to update groups
			ComponentPool<C1>.AddComponentEvent += AddComponent;
			ComponentPool<C2>.AddComponentEvent += AddComponent;

			ComponentPool<C1>.RemoveComponentEvent += RemoveComponent;
			ComponentPool<C2>.RemoveComponentEvent += RemoveComponent;
		}

		int C1_ID, C2_ID;							// component ID
		static List<C1> c1_components;				// reference to all components
		static List<C2> c2_components;
		static List<Entity> _activeEntities;		// all current active entities

		public delegate void componentMethod(C1 c1, C2 c2);	// method signature to call when processing components

		public void Process(componentMethod Method)
		{
			//Debug.Log(string.Format("{0} Active Entities", _activeEntities.Count));

			for (int i = 0; i < _activeEntities.Count; ++i)
			{
				Method
				(
					c1_components[EntityManager.EntityLookup[_activeEntities[i].ID][C1_ID]],
					c2_components[EntityManager.EntityLookup[_activeEntities[i].ID][C2_ID]]
				);
			}
		}

		// updates group when component is added
		void AddComponent(Entity e)
		{
			if(	EntityManager.EntityLookup[e.ID][C1_ID] > 0 &&
				EntityManager.EntityLookup[e.ID][C2_ID] > 0)
			{
				_activeEntities.Add(e);
			}
		}

		void RemoveComponent(Entity e)
		{
			_activeEntities.Remove(e);
		}

		/// <summary>
		/// Total amount of Entities in this Group
		/// </summary>
		public int EntityCount
		{
			get
			{
				return _activeEntities.Count;
			}
		}

		/// <summary>
		/// Returns active entity collection
		/// Read Only
		/// </summary>
//		public ICollection<Entity> ActiveEntityCollection
//		{
//			get 
//			{
//				return new ReadOnlyCollection<Entity>(_activeEntities);
//			}
//		}
	}
}
