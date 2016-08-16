using UnityEngine;
using System.Collections.Generic;
using System;
using ECS.Internal;

namespace ECS
{
	/// <summary>
	/// Group of entites that contain all Components
	/// </summary>
	public class Group<C1, C2, C3, C4>: Groups 
		where C1: EntityComponent, new()
		where C2: EntityComponent, new()
		where C3: EntityComponent, new()
		where C4: EntityComponent, new()
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
			_activeEntities = ComponentPool<C1>.GetActiveEntityList();
			_activeEntities.IntersectWith(ComponentPool<C2>.GetActiveEntityList());
			_activeEntities.IntersectWith(ComponentPool<C3>.GetActiveEntityList());
			_activeEntities.IntersectWith(ComponentPool<C4>.GetActiveEntityList());

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

		static HashSet<Entity> _activeEntities;		// all current active entities

		public delegate void componentMethod(C1 c1, C2 c2, C3 c3, C4 c4);	// method to call when processing components

		public void Process(componentMethod Method)
		{
			ProcessNewEntities();

			if (_activeEntities.Count == 0)	// early out if no subscribed components
				return;

			foreach(Entity e in _activeEntities)
			{
				Method
				(
					c1_components[e._GetComponentIndex(C1_ID)],
					c2_components[e._GetComponentIndex(C2_ID)],
					c3_components[e._GetComponentIndex(C3_ID)],
					c4_components[e._GetComponentIndex(C4_ID)]
				);
			}	
		}

		Queue<Entity> NewEntities = new Queue<Entity>();	// new entities, added before update
		void ProcessNewEntities()	// when new entity is added 
		{
			while (NewEntities.Count > 0)
			{
				Entity e = NewEntities.Dequeue();
				if (e.Has(C1_ID, C2_ID, C3_ID, C4_ID))	// one last check before begin processing
				{
					_activeEntities.Add(e);	
				}
			}
		}

		// updates group when component is added
		void AddComponent(Entity e)
		{
			if(	e.Has(C1_ID, C2_ID, C3_ID, C4_ID))
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
