using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

public abstract class EntitySystem<C1> : BaseEntitySystem, IEntityCount
	where C1 : EntityComponent<C1>
{
	/// 				///
	///   Properties	///
	/// 				///

	C1[] components		// reference to component group
	{
		get {return Group<C1>.instance.components;}
	}

	int componentCount	// how many compoennts in component group
	{
		get {return Group<C1>.instance.ComponentCount;}
	}

	bool _isActive;								// flags if system is active, needed since .enabled wasn't reliable
	Action OnEnableCallback = delegate {};		// callbacks used to manage events during system enable and disable
	Action OnDisableCallback = delegate {};

	/// 				///
	///   Unity Events	///
	/// 				///

	void Awake()
	{
		if (EntityManager.instance == null)		// if no instance of Entity Manager Destroy this object
		{
			Destroy(this);
			return;
		}

		EntityManager.instance.Systems.Add(this);	// Add this system to Entity Manager, this is used to display System Information on Entity Manager Inspector
		InitializeSystem();							// Initialize System Callback
		if (isUpdateSystem) EntityManager.instance.UpdateCallback += _ProcessUpdate;					// Add Update functions to Entity Manager Callbacks
		if (isFixedUpdateSystem) EntityManager.instance.FixedUpdateCallback += _ProcessFixedUpdate;
	}

	void OnDestroy()
	{
		if (EntityManager.instance == null) return;

		EntityManager.instance.Systems.Remove(this);	// remove system from entity manager
		OnEnableCallback = null;						// clear out callbacks, prevent class from staying alive due to weak references
		OnDisableCallback = null;
		if (isUpdateSystem) EntityManager.instance.UpdateCallback -= _ProcessUpdate;
		if (isFixedUpdateSystem) EntityManager.instance.FixedUpdateCallback -= _ProcessFixedUpdate;
	}

	void OnEnable()
	{
		_isActive = true;
		OnEnableCallback();
	}

	void OnDisable()
	{
		_isActive = false;
		OnDisableCallback();
	}

	void _ProcessUpdate()
	{
		if (_isActive)
		{
			for (int i = 0; i < componentCount; ++i)
			{
				UpdateSystem(components[i]);
			}
		}
	}

	void _ProcessFixedUpdate()
	{
		if (_isActive)
		{
			for (int i = 0; i < componentCount; ++i)
			{
				FixedUpdateSystem(components[i]);
			}
		}
	}
		
	/// 					///
	///   Public Functions	///
	/// 					///


	/// <summary>
	/// Method is Called Only Once during System Instantiation.
	/// This is where you should add all AddEvent Code and set if the system is and Update or FixedUpdate System
	/// </summary>
	public virtual void InitializeSystem()
	{}

	/// <summary>
	/// Does an update on all Entities that have this component enabled.
	/// </summary>
	public virtual void UpdateSystem(C1 c)
	{}

	/// <summary>
	/// Does a fixed update on all Entities that have this component enabled.
	/// </summary>
	public virtual void FixedUpdateSystem(C1 c)
	{}

	/// <summary>
	/// Does a manual update on all Entities that have this component enabled.
	/// Callback must match the Update signature
	/// </summary>
	public void ProcessComponents(Action<C1> callback)
	{
		for (int i = 0; i < componentCount; ++i)
		{
			callback(components[i]);
		}
	}

	/// <summary>
	/// Subscribes Callback to the Event Handler.
	/// Callback will fire on Entity the Event is sent to.
	/// Events should only be added during the Initialize System override. 
	/// Events are automatically added and removed during System enabled or disabled.
	/// </summary>
	public void AddEvent<E>(EntityEvent<E> callback)
	{
		OnEnableCallback += () => EntityManager.instance.AddEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveEvent(callback);
	}

	/// <summary>
	/// Returns how many Entities are currently using this System
	/// </summary>
	public int GetEntityCount ()
	{
		return componentCount;
	}
}


namespace SimpleECS.Internal
{
	public class Group
	{
		public virtual void Destroy()	// used to run cleanup code from the Entity Manager
		{}
	}

	public class Group<C>: Group where C : EntityComponent<C>
	{
		static Group<C> _i;
		public static Group<C> instance											// Yes this is singleton pattern. Fastest way I could find to get Component IDs
		{
			get 
			{
				if (_i == null && EntityManager.instance != null)				// Make sure that there is an Entity Manager
				{
					_i = EntityManager.instance.GetGroup<C>();					// Instances are actually created by Entity Manager
				}
				return _i;
			}
		}

		Dictionary<int, int> entityLookup = new Dictionary<int, int>(); 		// lookups for entity array positions
		public C[] components = new C[8];										// current list of all enabled components of type
		public int ComponentCount = 0;

		public System.Action<Entity> EnabledComponentCallback = delegate {};	// gets called when a component is enabled
		public System.Action<Entity> DisabledComponentCallback = delegate {};	// gets called when a component is disabled

		public void EnableComponent(C c)										// Called by the entity component when enabled
		{
			if (ComponentCount == components.Length)							// resize the array when full
			{
				Array.Resize( ref components, components.Length*2);
			}

			components[ComponentCount] = c; 									// add component to the end of array
			entityLookup.Add(c.entity.ID, ComponentCount); 						// add component index to dictionary lookups
			ComponentCount++;													// increaese amount of components
			EnabledComponentCallback(c.entity);									// signal to all groups that a new component has been added
		}

		public void DisableComponent(C c)
		{
			int arrayPos = entityLookup[c.entity.ID];							// get array position

			var lastComponent = components[ComponentCount -1];					// get last component
			components[arrayPos] = lastComponent;								// move last component to the removed component
			entityLookup[lastComponent.entity.ID] = arrayPos;					// update last component position

			-- ComponentCount;													// reduce the amount of components
			entityLookup.Remove(c.entity.ID);									// remove entity from lookup
			DisabledComponentCallback(c.entity);								// signal to groups that entity has been removed
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

		public override void Destroy ()												// on Destroy clear out all callbacks and remove the instance reference
		{
			EnabledComponentCallback = null;
			DisabledComponentCallback = null;
			_i = null;
		}
	}
}