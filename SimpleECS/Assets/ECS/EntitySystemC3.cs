using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

public class EntitySystem<C1, C2, C3>: BaseEntitySystem , IEntityCount	// EntitySystemC3 and above are the same as this class, just with more Generics
	where C1 : EntityComponent<C1> 
	where C2 : EntityComponent<C2>
	where C3 : EntityComponent<C3>
{
	Processor<C1, C2, C3>[] processors
	{
		get {return Group<C1,C2,C3>.instance.processors;}
	}

	int processorCount
	{
		get {return Group<C1,C2,C3>.instance.processorCount;}
	}


	bool _isActive;	// flags if system is active
	Action OnEnableCallback = delegate {};
	Action OnDisableCallback = delegate {};

	void Awake()
	{
		if (!EntityManager.loaded)
		{
			Debug.Log("Must Add Entity Manager to the Scene to use EntitySystems");
			return;
		}

		EntityManager.instance.Systems.Add(this); 	// this is so that the Entity Manager can show system information in the inspector
		InitializeSystem();
		if (this is UpdateSystem) EntityManager.instance.UpdateCallback += _ProcessUpdate;
		if (this is FixedUpdateSystem) EntityManager.instance.FixedUpdateCallback += _ProcessFixedUpdate;
	}

	void OnDestroy()
	{
		if (!EntityManager.loaded) return; 			// early out if no Entity Manager
		EntityManager.instance.Systems.Remove(this);
		OnEnableCallback = null;
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
		if (_isActive)
		{
			for (int i = 0; i < processorCount; ++i)
			{
				var process = processors[i];
				UpdateSystem(process.c1, process.c2, process.c3);
			}
		}
	}

	void _ProcessFixedUpdate()
	{
		if (_isActive)
		{
			for (int i = 0; i < processorCount; ++i)
			{
				var process = processors[i];
				FixedUpdateSystem(process.c1, process.c2, process.c3);
			}
		}
	}

	#region Public Functions

	/// <summary>
	/// Method is Called Only Once during System Instantiation.
	/// This is where you should add all AddEvent Code and set if the system is an Update or FixedUpdate System
	/// </summary>
	public virtual void InitializeSystem()
	{}

	/// <summary>
	/// Does an update on all Entities that have all components enabled.
	/// </summary>
	public virtual void UpdateSystem(C1 c1, C2 c2, C3 c3)
	{}

	/// <summary>
	/// Does a fixed update on all Entities that have all components enabled.
	/// </summary>
	public virtual void FixedUpdateSystem(C1 c1, C2 c2, C3 c3)
	{}

	/// <summary>
	/// Does a manual update on all Entities that have all components enabled.
	/// Callback must match the UpdateSystem signature
	/// </summary>
	public void ProcessComponents(Action<C1, C2, C3> callback)
	{
		for (int i = 0; i < processorCount; ++i)
		{
			var process = processors[i];
			callback(process.c1, process.c2, process.c3);
		}
	}

	/// <summary>
	/// Returns how many Entities are currently using this System
	/// </summary>
	public int GetEntityCount ()
	{
		return processorCount;
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
	public class Group<C1, C2, C3>: Group 
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
		where C3 : EntityComponent<C3>
	{
		static Group<C1,C2, C3> _i;
		public static Group<C1,C2, C3> instance	// Yes this is singleton pattern. Fastest way I could find to get Component IDs
		{
			get 
			{
				if (_i == null && EntityManager.loaded)										// if null and there is an Entity Manager, get set the instance value
				{
					_i = EntityManager.instance.GetGroup<C1,C2,C3>();						// Instances are actually created by Entity Manager and hopefully dies with it

					_i.AddEntities(Group<C1>.instance.GetEntities());						// On Instantiate Initialize processor list
					_i.AddEntities(Group<C2>.instance.GetEntities());
					_i.AddEntities(Group<C3>.instance.GetEntities());

					Group<C1>.instance.EnabledComponentEntityCallback += _i.OnEnableComponent;	// Subscribe to enable and disable callbacks to keep group up-to-date
					Group<C2>.instance.EnabledComponentEntityCallback += _i.OnEnableComponent;
					Group<C3>.instance.EnabledComponentEntityCallback += _i.OnEnableComponent;

					Group<C1>.instance.DisabledComponentEntityCallback += _i.OnDisableComponent;
					Group<C2>.instance.DisabledComponentEntityCallback += _i.OnDisableComponent;
					Group<C3>.instance.DisabledComponentEntityCallback += _i.OnDisableComponent;
				}
				return _i;
			}
		}

		Dictionary<int, int> entityLookup = new Dictionary<int, int>(); 	// lookups for entity array positions
		public Processor<C1,C2, C3>[] processors = new Processor<C1, C2, C3>[8];	// current list of all enabled components of type
		public int processorCount = 0;

		Processor<C1,C2,C3> newProcessor;

		public void OnEnableComponent(Entity e)	// Called by the component when enabled
		{
			if (entityLookup.ContainsKey(e.ID)) 				// early out if component is already added
				return;

			if (! (e.TryGetEnabled<C1>(out newProcessor.c1) 
				&& e.TryGetEnabled<C2>(out newProcessor.c2) 
				&& e.TryGetEnabled<C3>(out newProcessor.c3))) 	// early out if not all components are enabled
				return;

			if (processorCount == processors.Length)			// resize the array if full
			{
				Array.Resize( ref processors, processors.Length*2);
			}

			newProcessor.id = e.ID;
			processors[processorCount] = newProcessor; 			// add component to the end of array
			entityLookup.Add(e.ID, processorCount); 			// add component position to dictionary lookups
			++ processorCount;									// increaese amount of components
		}

		public void OnDisableComponent(Entity e)
		{
			int arrayPos;
			if (!entityLookup.TryGetValue(e.ID, out arrayPos)) 		// try get array position, early out if none
				return;
			var lastProcessor = processors[processorCount -1];		// get last processor
			processors[arrayPos] = lastProcessor;					// move the last processor to removed processor's position, keeps array contiguous
			entityLookup[lastProcessor.id] = arrayPos;				// update position of swapped processor
			-- processorCount;										// reduce the amount of processors in list
			entityLookup.Remove(e.ID);								// remove entity from lookup
		}

		void AddEntities(List<Entity> e)							// Adds a list of entities to system
		{
			for(int i = 0; i < e.Count; ++i)
			{
				OnEnableComponent(e[i]);	
			}
		}

		public override void Destroy ()		// clears singleton when destroyed, probably doesn't need it but just to be safe
		{
			_i = null;
		}
	}
		
	public struct Processor<C1, C2, C3>	// struct to keep track of processor components
	{
		public int id;
		public C1 c1;
		public C2 c2;
		public C3 c3;
	}
}
	