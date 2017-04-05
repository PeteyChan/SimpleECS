using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

public abstract class EntitySystem<C1> : BaseEntitySystem, IEntityCount
	where C1 : EntityComponent<C1>
{
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

	#if UNITY_EDITOR
	SimpleECS.Internal.SystemInfo info = new SimpleECS.Internal.SystemInfo();
	#endif

	void Awake()
	{
		if (!EntityManager.loaded)
		{
			Debug.Log("Must Add Entity Manager to the Scene to use EntitySystems");
			return;
		}

		#if UNITY_EDITOR	// used for displaying Simple ECS data in Entity Manager
		info.System = this;
		info.ComponentPoolTypes.Add(typeof(C1));
		EntityManager.instance.SystemsInfo.Add(info);
		#endif

		InitializeSystem();							// Initialize System Callback
		if (this is UpdateSystem) EntityManager.instance.UpdateCallback += _ProcessUpdate;					// Add Update functions to Entity Manager Callbacks
		if (this is FixedUpdateSystem) EntityManager.instance.FixedUpdateCallback += _ProcessFixedUpdate;
	}

	void OnDestroy()
	{
		if (!EntityManager.loaded) return; 			// early out if no Entity Manager

		#if UNITY_EDITOR
		EntityManager.instance.SystemsInfo.Remove(info);	// remove system from entity manager
		#endif

		OnEnableCallback = null;						// clear out callbacks, prevent class from staying alive due to weak references
		OnDisableCallback = null;
		if (this is UpdateSystem) EntityManager.instance.UpdateCallback -= _ProcessUpdate;
		if (this is FixedUpdateSystem) EntityManager.instance.FixedUpdateCallback -= _ProcessFixedUpdate;
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
		#if UNITY_EDITOR
		if (info.ShowInfo)
			info.StartUpdateTimer();
		#endif

		if (_isActive)
		{
			for (int i = 0; i < componentCount; ++i)
			{
				UpdateSystem(components[i]);
			}
		}

		#if UNITY_EDITOR
		if (info.ShowInfo)
			info.StopUpdateTimer();
		#endif
	}

	void _ProcessFixedUpdate()
	{
		#if UNITY_EDITOR
		if(info.ShowInfo)
			info.StartFixedUpdateTimer();
		#endif

		if (_isActive)
		{
			for (int i = 0; i < componentCount; ++i)
			{
				FixedUpdateSystem(components[i]);
			}
		}

		#if UNITY_EDITOR
		if (info.ShowInfo)
			info.StopFixedUpdateTimer();
		#endif
	}
		
	#region Public Functions

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
	/// Returns how many Entities are currently using this System
	/// </summary>
	public int GetEntityCount ()
	{
		return componentCount;
	}

	#endregion

	#region SystemEvents

	/// <summary>
	/// Subscribes callback to the Event Handler.
	/// Callback will be invoked when the event is sent to an entity.
	/// Events should only be added during Initialize System. 
	/// Events are automatically added and removed when System is enabled or disabled.
	/// </summary>
	public void AddEntityEvent<E>(EntityEvent<E> callback)	// using simple lambda functions to automate adding and removing events
	{
		OnEnableCallback += () => EntityManager.instance.AddEntityEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveEntityEvent(callback);

		#if UNITY_EDITOR
		info.EntityEvents.Add(typeof(E));
		#endif
	}

	/// <summary>
	/// Subscribes callback to the Event Handler.
	/// Callback will fire when component is enabled.
	/// Events are automatically added and removed when System is enabled or disabled.
	/// </summary>
	public void AddEnableComponentEvent<C>(Action<C> callback) where C : EntityComponent<C>
	{
		OnEnableCallback += () => Group<C>.instance.EnableComponentCallback += callback;
		OnDisableCallback += () => Group<C>.instance.EnableComponentCallback -= callback;
	
		#if UNITY_EDITOR
		info.EnableComponentEvent.Add(typeof(C));
		#endif
	}

	/// <summary>
	/// Subscribes callback to the Event Handler.
	/// Callback will fire when component is disabled.
	/// Events are automatically added and removed when System is enabled or disabled.
	/// </summary>
	public void AddDisableComponentEvent<C>(Action<C> callback) where C : EntityComponent<C>
	{
		OnEnableCallback += () => Group<C>.instance.DisableComponentCallback += callback;
		OnDisableCallback += () => Group<C>.instance.DisableComponentCallback -= callback;

		#if UNITY_EDITOR
		info.DisableComponentEvent.Add(typeof(C));
		#endif
	}

	/// <summary>
	/// Subscribes callback to the Event Handler.
	/// Callback will fire on when a System Sends the Event.
	/// Events are automatically added and removed when System is enabled or disabled.
	/// </summary>
	public void AddSystemEvent<E>(Action<E> callback)
	{
		OnEnableCallback += () => EntityManager.instance.AddSystemEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveSystemEvent(callback);

		#if UNITY_EDITOR
		info.SystemEvents.Add(typeof(E));
		#endif
	}

	/// <summary>
	/// Call the Event on all subscribed systems with specified arguments.
	/// </summary>
	public void SendSystemEvent<E>(E args)
	{
		EntityManager.instance.CallSystemEvent(args);
	}

	#endregion

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
				EnabledComponentEntityCallback(c.entity);							// signal to all groups that a new component has been added
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
				DisabledComponentEntityCallback(c.entity);							// signal to groups that entity has been removed
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
	}
}