using UnityEngine;
using System.Collections.Generic;
using System;

namespace ECS.Internal
{
	/// <summary>
	/// Keeps tracks of component pool and Entities that current have those components
	/// 
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
					ComponentPool pool = new ComponentPool<C>(ECSManager.GetComponentID<C>());
					ECSManager._componentLookUPs[ID] = pool;
				}
				return _ID;
			}
		}

		// List of all available components
		public static List<C> components = new List<C>(){null}; 					

		// index of components not currently in use
		static Stack<ushort> pooledComponents = new Stack<ushort>();		

		// list of active entities
		public static List<Entity> ActiveEntities = new List<Entity>();

		// Add and remove events
		static public ComponentEvent AddComponentEvent;				
		static public ComponentEvent RemoveComponentEvent;

		public static C GetOrAddComponent(Entity e)
		{
			ushort index = ECSManager.EntityLookup[e.ID][ID];	// get the index to component
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

			ECSManager.EntityLookup[e.ID][ID] = index; 		// set entity index
			components[index].entity = e;						// set components owner

			if (AddComponentEvent != null)						// fire add component event
				AddComponentEvent(e);

			ActiveEntities.Add(e);							// Enqueue Entity to be processed
			return components[index];							// and return the component
		}

		// sets entity component to value
		// used to hook into unity prefabs
		public static void SetComponent(Entity e, C c)
		{
			c.entity = e;											// sets component's owner
			ushort index = ECSManager.EntityLookup[e.ID][ID];	// get the index to component
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
			ECSManager.EntityLookup[e.ID][ID] = index; 		// set entity indexer to slot
			components[index] = c;								// set component to index

			if (AddComponentEvent != null)						// fire add component event
				AddComponentEvent(e);

			ActiveEntities.Add(e);								// Add Entity to active list
		}


		// It's safe to remove components that don't exist
		public static void RemoveComponent(Entity e)
		{	
			ushort index = ECSManager.EntityLookup[e.ID][ID];	// get the index to component
			if (index == 0)											// early out if no component
				return;

			ActiveEntities.Remove(e);							// remove entitiy from active list

			if (RemoveComponentEvent != null)
				RemoveComponentEvent(e);							// fire event to update pools

			pooledComponents.Push(index);						// add reference to pooled components
			ECSManager.EntityLookup[e.ID][ID] = 0; 			// remove reference to component
		}

		public override void BaseRemoveComponent (Entity e)		// used to call remove component from base class
		{
			RemoveComponent(e);
		}

		public static C GetComponent(Entity e)					// returns component if any
		{ 
			return components[ECSManager.EntityLookup[e.ID][ID]];							
		}

		public static List<C> GetComponentList()
		{
			return components;
		}

	}
}


