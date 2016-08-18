using UnityEngine;
using System.Collections.Generic;
using System;
using ECS.Internal;
using System.Collections.ObjectModel;

namespace ECS
{
	/* How to use
		 * Pool pool;	// cache pool
		 * 
		 * EntityPool.TryGetPool( MyComponent, out pool);	// get pool from entity pool
		 * 
		 * Pool.ProcessComponents((MyComponent component) => 	// how execute function
		 * ( code)); 
		 * 
		 */
	//
	//	SINGLE COMPONENT GROUP
	//

	public class Group<C>: Groups where C: EntityComponent
	{
		public Group()
		{
			ID = ComponentPool<C>.ID;
			_components = ComponentPool<C>.GetComponentList();

			ComponentPool<C>.AddComponentEvent += OnAddComponent;
			ComponentPool<C>.RemoveComponentEvent += OnRemoveComponent;
		}

		int ID;		// component ID
		static List<C> _components;		// reference to all components
		static List<Entity> _activeEntities = new List<Entity>();	// all current active entities, lists are much faster than hashsets < a few thousand elements
		public delegate void componentMethod(C component);			// method to call when processing components
			
		/// <summary>
		/// Processes all entites in pool.
		/// Use Lamba function for ease.
		/// E.g.
		/// group.Process( (MyComponent component) =>
		/// {
		/// 	component.value ++;
		/// } );
		/// </summary>
		public void Process(componentMethod method)
		{
			ProcessNewEntities();

			if (_activeEntities.Count == 0)
				return;
			
			foreach(Entity e in _activeEntities)
			{
				method(_components[EntityPool.EntityLookup[e.ID][ID]]);
			}	
		}

		Queue<Entity> NewEntities = new Queue<Entity>();	// new entities, added before update
		void ProcessNewEntities()	// when new entity is added 
		{
			while (NewEntities.Count > 0)
			{
				Entity e = NewEntities.Dequeue();
				if (EntityPool.EntityLookup[e.ID][ID] > -1)
				{
					_activeEntities.Add(e);	
				}
			}
		}

		public void OnAddComponent(Entity e)
		{
			NewEntities.Enqueue(e);
		}

		public void OnRemoveComponent(Entity e)
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

		public static List<Entity> GetActiveEntities()
		{
			return _activeEntities;
		}

//		public  ActiveEntities()
//		{
//			return new ActiveEntities(_activeEntities);
//		}
	}
}
