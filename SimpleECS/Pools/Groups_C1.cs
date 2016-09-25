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
			_activeEntities = ComponentPool<C>.ActiveEntities;
		}

		int ID;		// component ID
		List<C> _components;		// reference to all components
		List<Entity> _activeEntities;	// all current active entities, lists are much faster than hashsets < a few thousand elements

		public delegate void componentMethod(C component);			// method to call when processing components
			
		/// <summary>
		/// Processes all entites in pool.
		/// Use Lamba function for ease. Signature must match group
		/// E.g.
		/// group.Process( (MyComponent component) =>
		/// {
		/// 	// Do something with component
		/// } );
		/// </summary>
		public void Process(componentMethod Method)
		{
			for (int i= 0; i < _activeEntities.Count; ++i)
			{
				Method(_components[ECSManager.EntityComponentIndexLookup[_activeEntities[i].ID][ID]]);
			}
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
	}
}
