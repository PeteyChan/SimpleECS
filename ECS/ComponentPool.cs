using UnityEngine;
using System.Collections.Generic;
using System;

namespace ECS.Internal
{
	public delegate void ComponentEvent(Entity e);

	public abstract class ComponentPool
	{
		public virtual void BaseRemoveComponent(Entity e)
		{}
	}

	public class ComponentPool<C> : ComponentPool where C : EntityComponent, new ()
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
					EntityPool._componentLookUPs.Add(ID, pool);
					Groups.GetGroup<C>();	// Initialize Group
				}
				return _ID;
			}
		}

		static List<C> components = new List<C>(); 					// List of all available components
		static Stack<int> pooledComponents = new Stack<int>();		// index of components not currently in use

		public static HashSet<Entity> _activeEntities;
		static public ComponentEvent AddComponentEvent;				
		static public ComponentEvent RemoveComponentEvent;

		// Add Component is updated next Event Update
		public static C GetOrAddComponent(Entity e)
		{
			if (e.Has(ID)) // returns attached component if one's already attached
			{
				return GetComponent(e);
			}
			int index;							// index of new component
			if (pooledComponents.Count > 0)		// if there is an available component
			{
				index = pooledComponents.Pop();	// get index of pooled component
			}
			else
			{
				index = components.Count;		// get index of new component
				components.Add(new C());		// them make new component
			}
			e._SetComponentIndex(ID, index);	// set the entity index
			components[index].Entity = e;		// set components owner
			components[index].OnAdd();			// intialize the component
			AddComponentEvent(e);				// fire add component event
			return components[index];			// and return the component
		}

		// It's safe to remove components that don't exist
		public static void RemoveComponent(Entity e)
		{
			if (e.Has(ID))						// if has component
			{
				int index = e._GetComponentIndex(ID);	// get the index to component
				components[index].OnRemove();		// fire clean up code if any
				pooledComponents.Push(index);	// add to pooled components
				e._SetComponentIndex(ID, -1); 	// remove reference to component

				// add component to pool
				RemoveComponentEvent(e);		// fire remove component event
			}
		}

		public override void BaseRemoveComponent (Entity e)
		{
			RemoveComponent(e);
		}



		public static C GetComponent(Entity e)
		{
			if (e.Has(ID))					// check if have component and then return it
				return  components[e._GetComponentIndex(ID)];
			return null;					// else return null
		}

		public static List<C> GetComponentList()
		{
			return components;
		}

		public static HashSet<Entity> GetActiveEntityList()
		{
			if (_activeEntities == null)
			{
				Groups.GetGroup<C>();
			}
			return _activeEntities;
		}

	}
}


