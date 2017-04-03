using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

public class EntitySystem<C1, C2, C3, C4, C5>: BaseEntitySystem , IEntityCount	// EntitySystemC3 and above are the same as this class, just with more Generics
	where C1 : EntityComponent<C1> 
	where C2 : EntityComponent<C2>
	where C3 : EntityComponent<C3>
	where C4 : EntityComponent<C4>
	where C5 : EntityComponent<C5>
{

	/// 				///
	///   Properties	///
	/// 				///

	Processor<C1, C2, C3, C4, C5>[] processors
	{
		get {return Group<C1,C2,C3,C4,C5>.instance.processors;}
	}

	int processorCount
	{
		get {return Group<C1,C2,C3,C4,C5>.instance.processorCount;}
	}

	bool _isActive;	// flags if system is active
	Action OnEnableCallback = delegate {};
	Action OnDisableCallback = delegate {};


	/// 				///
	///   Unity Events	///
	/// 				///

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
				UpdateSystem(process.c1, process.c2, process.c3, process.c4, process.c5);
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
				FixedUpdateSystem(process.c1, process.c2, process.c3, process.c4, process.c5);
			}
		}
	}

	/// 					///
	///   Public Functions	///
	/// 					///

	/// <summary>
	/// Method is Called Only Once during System Instantiation.
	/// This is where you should add all AddEvent Code and set if the system is an Update or FixedUpdate System
	/// </summary>
	public virtual void InitializeSystem()
	{}

	/// <summary>
	/// Does an update on all Entities that have all components enabled.
	/// </summary>
	public virtual void UpdateSystem(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5)
	{}

	/// <summary>
	/// Does a fixed update on all Entities that have all components enabled.
	/// </summary>
	public virtual void FixedUpdateSystem(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5)
	{}

	/// <summary>
	/// Does a manual update on all Entities that have all components enabled.
	/// Callback must match the UpdateSystem signature
	/// </summary>
	public void ProcessComponents(Callback<C1, C2, C3, C4, C5> callback)
	{
		for (int i = 0; i < processorCount; ++i)
		{
			var process = processors[i];
			callback(process.c1, process.c2, process.c3, process.c4, process.c5);
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
		return processorCount;
	}
}

namespace SimpleECS.Internal
{
	public delegate void Callback<C1,C2,C3,C4,C5>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5);

	public class Group<C1, C2, C3, C4, C5>: Group 
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
		where C3 : EntityComponent<C3>
		where C4 : EntityComponent<C4>
		where C5 : EntityComponent<C5>
	{
		static Group<C1,C2, C3, C4, C5> _i;
		public static Group<C1,C2,C3,C4, C5> instance	// Yes this is singleton pattern. Fastest way I could find to get Component IDs
		{
			get 
			{
				if (_i == null && EntityManager.instance != null)							// if null and there is an Entity Manager, get set the instance value
				{
					_i = EntityManager.instance.GetGroup<C1,C2,C3,C4,C5>();					// Instances are actually created by Entity Manager and hopefully dies with it

					_i.AddEntities(Group<C1>.instance.GetEntities());						// On Instantiate Initialize processor list
					_i.AddEntities(Group<C2>.instance.GetEntities());
					_i.AddEntities(Group<C3>.instance.GetEntities());
					_i.AddEntities(Group<C4>.instance.GetEntities());
					_i.AddEntities(Group<C5>.instance.GetEntities());

					Group<C1>.instance.EnabledComponentCallback += _i.OnEnableComponent;	// Subscribe to enable and disable callbacks to keep group up-to-date
					Group<C2>.instance.EnabledComponentCallback += _i.OnEnableComponent;
					Group<C3>.instance.EnabledComponentCallback += _i.OnEnableComponent;
					Group<C4>.instance.EnabledComponentCallback += _i.OnEnableComponent;
					Group<C5>.instance.EnabledComponentCallback += _i.OnEnableComponent;

					Group<C1>.instance.DisabledComponentCallback += _i.OnDisableComponent;
					Group<C2>.instance.DisabledComponentCallback += _i.OnDisableComponent;
					Group<C3>.instance.DisabledComponentCallback += _i.OnDisableComponent;
					Group<C4>.instance.DisabledComponentCallback += _i.OnDisableComponent;
					Group<C5>.instance.DisabledComponentCallback += _i.OnDisableComponent;
				}
				return _i;
			}
		}

		Dictionary<int, int> entityLookup = new Dictionary<int, int>(); 	// lookups for entity array positions
		public Processor<C1,C2,C3,C4,C5>[] processors = new Processor<C1,C2,C3,C4,C5>[8];	// current list of all enabled components of type
		public int processorCount = 0;

		Processor<C1,C2,C3,C4,C5> newProcessor;

		public void OnEnableComponent(Entity e)	// Called by the component when enabled
		{
			if (entityLookup.ContainsKey(e.ID)) 				// early out if component is already added
				return;

			if (! (e.TryGetEnabled<C1>(out newProcessor.c1) 
				&& e.TryGetEnabled<C2>(out newProcessor.c2) 
				&& e.TryGetEnabled<C3>(out newProcessor.c3) 
				&& e.TryGetEnabled<C4>(out newProcessor.c4) 
				&& e.TryGetEnabled<C5>(out newProcessor.c5))) 	// early out if not all components are enabled
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
		
	public struct Processor<C1, C2, C3, C4, C5>	// struct to keep track of processor components
	{
		public int id;
		public C1 c1;
		public C2 c2;
		public C3 c3;
		public C4 c4;
		public C5 c5;
	}
}
	