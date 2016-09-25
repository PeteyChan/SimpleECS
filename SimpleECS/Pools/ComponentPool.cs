using UnityEngine;
using System.Collections.Generic;
using System;

namespace ECS.Internal
{
	/// <summary>
	/// Keeps tracks of component pool and Entities that current have those components
	/// 
	/// </summary>

	public delegate void EntityEvent (Entity e);
	public delegate void ComponentEvent<C>(C Component) where C : EntityComponent;

	public abstract class ComponentPool
	{
		public virtual void BaseRemoveComponent(Entity e)	// used to remove components without knowing the generic's type
		{}

		public virtual void BaseAddComponent(Entity e)
		{}

		public virtual void ClearPools()
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
					ComponentPool pool = new ComponentPool<C>(ECSManager.GetComponentID<C>());
					ECSManager._componentPoolByID[ID] = pool;
					ECSManager.componentPoolCount ++;

					components = new List<C>(){null};
					pooledComponents = new Stack<ushort>();
					ActiveEntities = new List<Entity>();
				}
				return _ID;
			}
		}

		//
		//	COLLECTIONS
		//

		// List of all available components
		public static List<C> components; 					

		// index of components not currently in use
		static Stack<ushort> pooledComponents;		

		// list of active entities
		public static List<Entity> ActiveEntities;

		// Add and remove events
		static public ComponentEvent<C> AddComponentEvent;				
		static public ComponentEvent<C> RemoveComponentEvent;

		static public EntityEvent AddEntityEvent;
		static public EntityEvent RemoveEntityEvent;

		//
		//	METHODS
		//

		public static C GetOrAddComponent(Entity e)
		{
			ushort index = ECSManager.EntityComponentIndexLookup[e.ID][ID];	// get the index to component
			if (index > 0)										// if has component return component
				return components[index];		
			if (pooledComponents.Count > 0)						// if there is an available component
			{
				index = pooledComponents.Pop();					// get index of pooled component
				components[index] = Activator.CreateInstance<C>();	// this is to ensure Set<C> works properly and not setting references everywhere
			}
			else
			{
				index = (ushort)components.Count;				// get index of new component
				components.Add(Activator.CreateInstance<C>()); 	// them make new component		
			}

			ECSManager.EntityComponentIndexLookup[e.ID][ID] = index; 		// set entity index
			components[index].entity = e;						// set components owner

			if (AddComponentEvent != null)						// fire add component event
				AddComponentEvent(components[index]);

			if (AddEntityEvent != null)
				AddEntityEvent(e);


			ActiveEntities.Add(e);							// Enqueue Entity to be processed
			return components[index];							// and return the component
		}

		// sets entity component to value
		// used to hook into unity prefabs
		public static void SetComponent(Entity e, C c)
		{
			ushort index = ECSManager.EntityComponentIndexLookup[e.ID][ID];	// get the index to component
			if (index > 0)											// if has component, replace it and return
			{
				components[index] = c;
				return;
			}		
			if (pooledComponents.Count > 0)						// if there is an available component slot
			{
				index = pooledComponents.Pop();					// get index of component slot
			}
			else
			{
				index = (ushort)components.Count;				// get index of new component
				components.Add(null); 							// then add new slot		
			}
			ECSManager.EntityComponentIndexLookup[e.ID][ID] = index; 		// set entity indexer to slot
			components[index] = c;								// set component to index
			c.entity = e;											// sets component's owner

			if (AddComponentEvent != null)						// fire add component event
				AddComponentEvent(components[index]);

			if (AddEntityEvent != null)
				AddEntityEvent(e);

			ActiveEntities.Add(e);								// Add Entity to active list
		}


		// It's safe to remove components that don't exist
		public static void RemoveComponent(Entity e)
		{	
			ushort index = ECSManager.EntityComponentIndexLookup[e.ID][ID];	// get the index to component
			if (index == 0)											// early out if no component
				return;

			ActiveEntities.Remove(e);								// remove entitiy from active list

			if (RemoveComponentEvent != null)
				RemoveComponentEvent(components[index]);			// fire event to update pools

			if (RemoveEntityEvent != null)
				RemoveEntityEvent(e);

			pooledComponents.Push(index);							// add reference to pooled components
			ECSManager.EntityComponentIndexLookup[e.ID][ID] = 0; 	// remove reference to component
		}

		public override void BaseRemoveComponent (Entity e)		// used to call remove component from base class
		{
			RemoveComponent(e);
		}

		public override void BaseAddComponent (Entity e)
		{
			GetOrAddComponent(e);
		}

		public static C GetComponent(Entity e)					// returns component if any
		{ 
			return components[ECSManager.EntityComponentIndexLookup[e.ID][ID]];							
		}

		public static List<C> GetComponentList()
		{
			return components;
		}

		public override void ClearPools()
		{
			AddComponentEvent = null;
			RemoveComponentEvent = null;
			AddEntityEvent = null;
			RemoveEntityEvent = null;
			_ID = -1;
		}
	}
}


