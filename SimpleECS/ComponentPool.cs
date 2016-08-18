using UnityEngine;
using System.Collections.Generic;
using System;

namespace ECS.Internal
{
	/// <summary>
	/// The comonent pool is separated from the groups pool simply because I didn't
	/// want add and remove function and other variables visible during general use
	/// </summary>

	public delegate void ComponentEvent(Entity e);

	public abstract class ComponentPool
	{
		public virtual void BaseRemoveComponent(Entity e)	// used to remove components without knowing the generic's type
		{}

	}

	public class ComponentPool<C> : ComponentPool where C : EntityComponent
	{
		ComponentPool(int _id)	// set pool ID on initialize
		{
			_ID = _id;
		}

		static int _ID = -1;	// -1 means uninitialized;
		public static int ID
		{
			get
			{
				if (_ID < 0)	// if pool not initialized, initialize pool
				{
					ComponentPool pool = new ComponentPool<C>(EntityPool.GetComponentID<C>());
					EntityPool._componentLookUPs[ID] = pool;
					Groups.GetGroup<C>();	// Initialize associated Group
				}
				return _ID;
			}
		}

		// List of all available components
		static List<C> components = new List<C>(); 					

		// index of components not currently in use
		static Stack<short> pooledComponents = new Stack<short>();		

		// Add and remove events
		static public ComponentEvent AddComponentEvent;				
		static public ComponentEvent RemoveComponentEvent;

		public static C GetOrAddComponent(Entity e)
		{
			short index = EntityPool.EntityLookup[e.ID][ID];	// get the index to component
			if (index > -1)						// if has component return component
				return components[index];		
			if (pooledComponents.Count > 0)		// if there is an available component
			{
				index = pooledComponents.Pop();	// get index of pooled component
			}
			else
			{
				index = (short)components.Count;	// get index of new component
				components.Add(Activator.CreateInstance<C>());
				//components.Add(new C());			// them make new component
			}
			EntityPool.EntityLookup[e.ID][ID] = index; // set entity index
			components[index].Entity = e;		// set components owner
			components[index].OnAdd();			// intialize the component
			AddComponentEvent(e);				// fire add component event
			return components[index];			// and return the component
		}

		// It's safe to remove components that don't exist
		public static void RemoveComponent(Entity e)
		{
			short index = EntityPool.EntityLookup[e.ID][ID];	// get the index to component
			if (index < 0)	// early out if no component
				return;
			components[index].OnRemove();			// fire clean up code if any, this is probably pointless
			pooledComponents.Push(index);			// add reference to pooled components
			EntityPool.EntityLookup[e.ID][ID] = -1; // remove reference to component
			RemoveComponentEvent(e);				// fire remove component event
		}

		public override void BaseRemoveComponent (Entity e)	// used to call remove component from base class
		{
			RemoveComponent(e);
		}

		public static C GetComponent(Entity e)	// does a lookup and returns component if any
		{
			short index = EntityPool.EntityLookup[e.ID][ID];
			if (index < 0)								
				return null; 
			return components[index];							
		}

		public static List<C> GetComponentList()
		{
			return components;
		}
	}
}


