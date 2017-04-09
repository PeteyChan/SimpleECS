using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SimpleECS.Internal
{
	public class Group
	{
		public virtual void Destroy()	// used to run cleanup code from the Entity Manager
		{}

		public virtual int Count
		{
			get{return 0;}
		}
	}

	public class Group<C>: Group where C : EntityComponent<C>
	{
		static Group<C> _i;
		public static Group<C> instance											// Yes this is singleton pattern. Fastest way I could find to get Component IDs
		{
			get 
			{
				if (_i == null && EntityManager.loaded)							// Make sure that there is an Entity Manager
				{
					_i = EntityManager.instance.GetGroup<C>();					// Instances are actually created by Entity Manager
				}
				return _i;
			}
		}

		Dictionary<int, int> entityLookup = new Dictionary<int, int>(); 		// lookups for entity array positions
		public C[] components = new C[8];										// current list of all enabled components of type
		public int ComponentCount = 0;

		public System.Action<Entity> EnabledComponentEntityCallback = delegate {};	// gets called when a component is enabled
		public System.Action<Entity> DisabledComponentEntityCallback = delegate {};	// gets called when a component is disabled

		public System.Action<C> EnableComponentCallback;
		public System.Action<C> DisableComponentCallback;

		public void EnableComponent(C c)										// Called by the entity component when enabled
		{
			if (ComponentCount == components.Length)							// resize the array when full
			{
				Array.Resize( ref components, components.Length*2);
			}

			components[ComponentCount] = c; 									// add component to the end of array
			entityLookup.Add(c.entity.ID, ComponentCount); 						// add component index to dictionary lookups
			ComponentCount++;													// increaese amount of components

			if (EnabledComponentEntityCallback != null)
				EnabledComponentEntityCallback(c.entity);						// signal to all groups that a new component has been added
			if (EnableComponentCallback != null)
				EnableComponentCallback(c);
		}

		public void DisableComponent(C c)
		{
			int arrayPos = entityLookup[c.entity.ID];							// get array position
			var lastComponent = components[ComponentCount -1];					// get last component
			components[arrayPos] = lastComponent;								// move last component to the removed component
			entityLookup[lastComponent.entity.ID] = arrayPos;					// update last component position

			-- ComponentCount;													// reduce the amount of components
			entityLookup.Remove(c.entity.ID);									// remove entity from lookup

			if (DisabledComponentEntityCallback != null)
				DisabledComponentEntityCallback(c.entity);						// signal to groups that entity has been removed
			if (DisableComponentCallback != null)
				DisableComponentCallback(c);
		}

		List<Entity> entityList = new List<Entity>();							// function to return alist of entities in this group
		public List<Entity> GetEntities()
		{
			entityList.Clear();
			for (int i = 0; i < ComponentCount; ++i)
			{
				entityList.Add(components[i].entity);
			}
			return entityList;
		}

		public int ID;															// group ID is the position of this component in the Entity's component lookup table 
		public Group(int ID)
		{
			this.ID = ID;
		}

		public override void Destroy ()											// on Destroy clear out all callbacks and remove the instance reference
		{
			EnabledComponentEntityCallback = null;
			DisabledComponentEntityCallback = null;
			_i = null;
		}

		public override int Count {
			get 
			{
				return ComponentCount;
			}
		}
	}
}