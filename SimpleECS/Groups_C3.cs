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
	public class Group<C1, C2, C3>: Groups 
		where C1: EntityComponent
		where C2: EntityComponent
		where C3: EntityComponent
	{
		public Group()
		{
			// get component IDs
			C1_ID = ComponentPool<C1>.ID;
			C2_ID = ComponentPool<C2>.ID;
			C3_ID = ComponentPool<C3>.ID;

			// get components list
			c1_components = ComponentPool<C1>.GetComponentList();
			c2_components = ComponentPool<C2>.GetComponentList();
			c3_components = ComponentPool<C3>.GetComponentList();

			_activeEntities = Group<C1>.GetActiveEntities()
				.Intersect(Group<C2>.GetActiveEntities())
				.Intersect(Group<C3>.GetActiveEntities()).ToList();

			// listen for changes to components to update groups
			ComponentPool<C1>.AddComponentEvent += AddComponent;
			ComponentPool<C2>.AddComponentEvent += AddComponent;
			ComponentPool<C3>.AddComponentEvent += AddComponent;

			ComponentPool<C1>.RemoveComponentEvent += RemoveComponent;
			ComponentPool<C2>.RemoveComponentEvent += RemoveComponent;
			ComponentPool<C3>.RemoveComponentEvent += RemoveComponent;
		}

		int C1_ID, C2_ID, C3_ID;							// component ID
		static List<C1> c1_components;				// reference to all components
		static List<C2> c2_components;
		static List<C3> c3_components;
		static List<Entity> _activeEntities;		// all current active entities

		public delegate void componentMethod(C1 c1, C2 c2, C3 c3);	// method to call when processing components

		public void Process(componentMethod Method)
		{
			ProcessNewEntities();

			if (_activeEntities.Count == 0)	// early out if no subscribed components
				return;

			foreach(Entity e in _activeEntities)
			{
				Method
				(
					c1_components[EntityPool.EntityLookup[e.ID][C1_ID]],
					c2_components[EntityPool.EntityLookup[e.ID][C2_ID]],
					c3_components[EntityPool.EntityLookup[e.ID][C3_ID]]
				);
			}
		}

		Queue<Entity> NewEntities = new Queue<Entity>();	// new entities, added before update
		void ProcessNewEntities()	// when new entity is added 
		{
			while (NewEntities.Count > 0)
			{
				Entity e = NewEntities.Dequeue();
				if (EntityPool.EntityLookup[e.ID][C1_ID] > -1 &&
					EntityPool.EntityLookup[e.ID][C2_ID] > -1 &&
					EntityPool.EntityLookup[e.ID][C3_ID] > -1)		// one last check before begin processing
				{
					_activeEntities.Add(e);	
				}
			}
		}

		// updates group when component is added
		void AddComponent(Entity e)
		{
			if(	EntityPool.EntityLookup[e.ID][C1_ID] > -1 &&
				EntityPool.EntityLookup[e.ID][C2_ID] > -1 &&
				EntityPool.EntityLookup[e.ID][C3_ID] > -1)
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
