using UnityEngine;
using System.Collections.Generic;
using System;
using ECS.Internal;
using System.Linq;

namespace ECS
{
	/// <summary>
	/// Group of entites that contain all Components
	/// </summary>
	public class Group<C1, C2, C3, C4>: Groups 
		where C1: EntityComponent
		where C2: EntityComponent
		where C3: EntityComponent
		where C4: EntityComponent
	{
		public Group()
		{
			// get component IDs
			C1_ID = ComponentPool<C1>.ID;
			C2_ID = ComponentPool<C2>.ID;
			C3_ID = ComponentPool<C3>.ID;
			C4_ID = ComponentPool<C4>.ID;

			// get components list
			c1_components = ComponentPool<C1>.GetComponentList();
			c2_components = ComponentPool<C2>.GetComponentList();
			c3_components = ComponentPool<C3>.GetComponentList();
			c4_components = ComponentPool<C4>.GetComponentList();

			// get entites with both components

			_activeEntities = ComponentPool<C1>.ActiveEntities
				.Intersect(ComponentPool<C2>.ActiveEntities)
				.Intersect(ComponentPool<C3>.ActiveEntities)
				.Intersect(ComponentPool<C4>.ActiveEntities).ToList();

			// listen for changes to components to update groups
			ComponentPool<C1>.AddComponentEvent += AddComponent;
			ComponentPool<C2>.AddComponentEvent += AddComponent;
			ComponentPool<C3>.AddComponentEvent += AddComponent;
			ComponentPool<C4>.AddComponentEvent += AddComponent;

			ComponentPool<C1>.RemoveComponentEvent += RemoveComponent;
			ComponentPool<C2>.RemoveComponentEvent += RemoveComponent;
			ComponentPool<C3>.RemoveComponentEvent += RemoveComponent;
			ComponentPool<C4>.RemoveComponentEvent += RemoveComponent;
		}

		int C1_ID, C2_ID, C3_ID, C4_ID;							// component ID

		static List<C1> c1_components;				// reference to all components
		static List<C2> c2_components;
		static List<C3> c3_components;
		static List<C4> c4_components;

		static List<Entity> _activeEntities;		// all current active entities

		public delegate void componentMethod(C1 c1, C2 c2, C3 c3, C4 c4);	// method to call when processing components

		public void Process(componentMethod Method)
		{
			for (int i = 0; i < _activeEntities.Count; ++i)
			{
				Method
				(
					c1_components[EntityManager.EntityLookup[_activeEntities[i].ID][C1_ID]],
					c2_components[EntityManager.EntityLookup[_activeEntities[i].ID][C2_ID]],
					c3_components[EntityManager.EntityLookup[_activeEntities[i].ID][C3_ID]],
					c4_components[EntityManager.EntityLookup[_activeEntities[i].ID][C4_ID]]
				);
			}

			ProcessEntities();
		}

		Queue<Entity> NewEntities = new Queue<Entity>();	// new entities, added before update
		void ProcessEntities()	// when new entity is added 
		{
			while (NewEntities.Count > 0)
			{
				Entity e = NewEntities.Dequeue();
				if (EntityManager.EntityLookup[e.ID][C1_ID] > 0 &&
					EntityManager.EntityLookup[e.ID][C2_ID] > 0 &&
					EntityManager.EntityLookup[e.ID][C3_ID] > 0 &&
					EntityManager.EntityLookup[e.ID][C4_ID] > 0)	// one last check before begin processing
				{
					_activeEntities.Add(e);	
				}
			}
		}

		// updates group when component is added
		void AddComponent(Entity e)
		{
			if(	EntityManager.EntityLookup[e.ID][C1_ID] > 0 &&
				EntityManager.EntityLookup[e.ID][C2_ID] > 0 &&
				EntityManager.EntityLookup[e.ID][C3_ID] > 0 &&
				EntityManager.EntityLookup[e.ID][C4_ID] > 0)
			{
				NewEntities.Enqueue(e);
			}
		}

		void RemoveComponent(Entity e)
		{
			_activeEntities.Remove(e);
		}

		/// <summary>
		/// Total amount of Entities in this Group
		/// </summary>
		public int EntityCount()
		{
			return _activeEntities.Count;
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
