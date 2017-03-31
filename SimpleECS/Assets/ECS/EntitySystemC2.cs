using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

public class EntitySystem<C1, C2>: BaseEntitySystem , IEntityCount	// EntitySystemC3 and above are the same as this class, just with more Generics
	where C1 : EntityComponent<C1> 
	where C2 : EntityComponent<C2>
{
	// This is just a holder I can iterate over
	// May be better as a Struct, not sure
	class Processor
	{
		public Processor(Entity e)
		{
				id = e.ID;
				c1 = e.Get<C1>();
				c2 = e.Get<C2>();
		}
		public int id;
		public C1 c1;
		public C2 c2;

		public override int GetHashCode () // I was originally thinking of using HashSet for efficient Adding and Removal but iterating over Hashsets is slow
		{
			return id;
		}
	}

	List<Processor> processor = new List<Processor>();
	HashSet<int> id = new HashSet<int>();	// Just a simple way to keep track of entity's in the system

	Action OnEnableCallback = delegate {};
	Action OnDisableCallback = delegate {};

	void Awake()
	{
		EntityManager.instance.Systems.Add(this);
		InitializeSystem();
		if (this is IUpdate) EntityManager.instance.UpdateCallback += _ProcessUpdate;
		if (this is IFixedUpdate) EntityManager.instance.FixedUpdateCallback += _ProcessFixedUpdate;
	}

	void OnDestroy()
	{
		EntityManager.instance.Systems.Remove(this);
		OnEnableCallback = null;
		OnDisableCallback = null;
		if (this is IUpdate) EntityManager.instance.UpdateCallback -= _ProcessUpdate;
		if (this is IFixedUpdate) EntityManager.instance.FixedUpdateCallback -= _ProcessFixedUpdate;
	}

	bool _active;
	void OnEnable()
	{
		_active = true;
		if (EntityManager.instance != null)
		{
			SetUP();	// this is a little costly due to the Linq process

			Group<C1>.instance.EnabledComponentCallback += AddEntity;	// this keeps track of any components that may need to be added to the system
			Group<C2>.instance.EnabledComponentCallback += AddEntity;

			Group<C1>.instance.DisabledComponentCallback += RemoveEntity;
			Group<C2>.instance.DisabledComponentCallback += RemoveEntity;

			OnEnableCallback();
		}

	}

	void OnDisable()
	{
		_active = false;
		if (EntityManager.instance != null)
		{
			Group<C1>.instance.EnabledComponentCallback -= AddEntity;
			Group<C2>.instance.EnabledComponentCallback -= AddEntity;

			Group<C1>.instance.DisabledComponentCallback -= RemoveEntity;
			Group<C2>.instance.DisabledComponentCallback -= RemoveEntity;

			OnDisableCallback();
		}
	}

	/// <summary>
	/// Method is Called Only Once during System Instantiation.
	/// This is where you should add all AddEvent Code
	/// </summary>
	public virtual void InitializeSystem()
	{}

	public virtual void UpdateSystem(C1 c1, C2 c2)
	{}

	public virtual void FixedUpdateSystem(C1 c1, C2 c2)
	{}

	/// <summary>
	/// Subscribes Callback to the Event Handler.
	/// Events are automatically added and removed when System is enabled or disabled
	/// </summary>
	public void AddEvent<E>(EntityEvent<E> callback)
	{
		OnEnableCallback += () => EntityManager.instance.AddEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveEvent(callback);
	}


	void AddEntity(Entity e)
	{
		if (id.Contains(e.ID))	// early out if already in system
			return;
		
		if (e.HasEnabled<C1>() && e.HasEnabled<C2>())	// check if entity contains components and add it to the processing list if it does
		{
			processor.Add(new Processor(e));
			id.Add(e.ID);
		}
	}

	void RemoveEntity(Entity e)
	{
		if (!id.Contains(e.ID)) // early out if not in the list
			return;
		
		id.Remove(e.ID);

		for (int i = 0; i < processor.Count; ++i) // unfortunately I can't think of a faster way to do this
		{
			if (processor[i].id == e.ID)
			{
				processor.RemoveAt(i);
				return;
			}
		}
	}

	void SetUP()
	{
		processor.Clear();

		List<C1> c1 = Group<C1>.instance.componentList;
		List<C2> c2 = Group<C2>.instance.componentList;

		var entities1 = from c in c1
			select c.entity;
		var entities2 = from c in c2
			select c.entity;
		var entities = entities1.Intersect(entities2);

		foreach(var entity in entities)
		{
			id.Add(entity.ID);
			processor.Add(new Processor(entity)); // maybe cache Processors or use structs, I'll figure out if I need to in the future
		}
	}

	void _ProcessUpdate()
	{
		if (_active)
		{
			for (int i = 0; i < processor.Count; ++i)
			{
				var process = processor[i];
				UpdateSystem(process.c1, process.c2);
			}
		}
	}

	void _ProcessFixedUpdate()
	{
		if (_active)
		{
			for (int i = 0; i < processor.Count; ++i)
			{
				var process = processor[i];
				FixedUpdateSystem(process.c1, process.c2);
			}
		}
	}

	/// <summary>
	/// Allows manual processing of components
	/// Callback must match the Update signature
	/// </summary>
	public void ProcessComponents(Action<C1, C2> callback)
	{
		for (int i = 0; i < processor.Count; ++i)
		{
			callback(processor[i].c1, processor[i].c2);
		}
	}

	/// <summary>
	/// Returns how many Entities using this System
	/// </summary>
	public int GetEntityCount ()
	{
		return processor.Count;
	}
}
