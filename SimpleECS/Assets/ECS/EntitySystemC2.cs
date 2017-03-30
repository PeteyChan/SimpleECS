using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

public class EntitySystem<C1, C2>: BaseEntitySystem , IEntityCount
	where C1 : EntityComponent<C1> 
	where C2 : EntityComponent<C2>
{
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

		public override int GetHashCode ()
		{
			return id;
		}
	}

	List<Processor> processor = new List<Processor>();
	HashSet<int> id = new HashSet<int>();

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
			SetUP();

			Group<C1>.instance.AddComponentCallback += AddEntity;
			Group<C2>.instance.AddComponentCallback += AddEntity;

			Group<C1>.instance.RemoveComponentCallback += RemoveEntity;
			Group<C2>.instance.RemoveComponentCallback += RemoveEntity;

			OnEnableCallback();
		}

	}

	void OnDisable()
	{
		_active = false;
		if (EntityManager.instance != null)
		{
			Group<C1>.instance.AddComponentCallback -= AddEntity;
			Group<C2>.instance.AddComponentCallback -= AddEntity;

			Group<C1>.instance.RemoveComponentCallback -= RemoveEntity;
			Group<C2>.instance.RemoveComponentCallback -= RemoveEntity;

			OnDisableCallback();
		}
	}

	public virtual void InitializeSystem()
	{}

	public virtual void UpdateSystem(C1 c1, C2 c2)
	{}

	public virtual void FixedUpdateSystem(C1 c1, C2 c2)
	{}

	public void AddEvent<E>(EntityEvent<E> callback)
	{
		OnEnableCallback += () => EntityManager.instance.AddEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveEvent(callback);
	}


	void AddEntity(Entity e)
	{
		if (id.Contains(e.ID))
			return;
		
		if (e.HasEnabled<C1>() && e.HasEnabled<C2>())
		{
			processor.Add(new Processor(e));
			id.Add(e.ID);
		}
	}

	void RemoveEntity(Entity e)
	{
		if (!id.Contains(e.ID))
			return;
		
		id.Remove(e.ID);

		for (int i = 0; i < processor.Count; ++i)
		{
			if (processor[i].id == e.ID)
			{
				processor.RemoveAt(i);
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
		var entities = entities1.Intersect(entities2);//.ToList();

		foreach(var entity in entities)
		{
			id.Add(entity.ID);
			processor.Add(new Processor(entity));
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
