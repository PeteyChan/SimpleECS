using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

public class EntitySystem<C1, C2, C3, C4>: BaseEntitySystem , IEntityCount
	where C1 : EntityComponent<C1> 
	where C2 : EntityComponent<C2>
	where C3 : EntityComponent<C3>
	where C4 : EntityComponent<C4>
{
	
	class Processor
	{
		public Processor(Entity e)
		{
			id = e.ID;
			c1 = e.Get<C1>();
			c2 = e.Get<C2>();
			c3 = e.Get<C3>();
			c4 = e.Get<C4>();
		}

		public int id;
		public C1 c1;
		public C2 c2;
		public C3 c3;
		public C4 c4;

		public override int GetHashCode ()
		{
			return id;
		}
	}

	List<Processor> processor = new List<Processor>();
	HashSet<int> id = new HashSet<int>();

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
			Group<C3>.instance.AddComponentCallback += AddEntity;
			Group<C4>.instance.AddComponentCallback += AddEntity;

			Group<C1>.instance.RemoveComponentCallback += RemoveEntity;
			Group<C2>.instance.RemoveComponentCallback += RemoveEntity;
			Group<C3>.instance.RemoveComponentCallback += RemoveEntity;
			Group<C4>.instance.RemoveComponentCallback += RemoveEntity;
		}
		OnEnableCallback();
	}

	void OnDisable()
	{
		_active = false;
		if (EntityManager.instance != null)
		{
			Group<C1>.instance.AddComponentCallback -= AddEntity;
			Group<C2>.instance.AddComponentCallback -= AddEntity;
			Group<C3>.instance.AddComponentCallback -= AddEntity;
			Group<C4>.instance.AddComponentCallback -= AddEntity;

			Group<C1>.instance.RemoveComponentCallback -= RemoveEntity;
			Group<C2>.instance.RemoveComponentCallback -= RemoveEntity;
			Group<C3>.instance.RemoveComponentCallback -= RemoveEntity;
			Group<C4>.instance.RemoveComponentCallback -= RemoveEntity;
		}
		OnDisableCallback();
	}


	public virtual void InitializeSystem()
	{}

	Action OnEnableCallback = delegate {};
	Action OnDisableCallback = delegate {};

	public void AddEvent<E>(EntityEvent<E> callback)
	{
		OnEnableCallback += () => EntityManager.instance.AddEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveEvent(callback);
	}


	void AddEntity(Entity e)
	{
		if (id.Contains(e.ID))
			return;
		
		if (e.HasEnabled<C1>() && e.HasEnabled<C2>() && e.HasEnabled<C3>() && e.HasEnabled<C4>())
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
				return;
			}
		}
	}
		
	void SetUP()
	{
		processor.Clear();

		List<C1> c1 = Group<C1>.instance.componentList;
		List<C2> c2 = Group<C2>.instance.componentList;
		List<C3> c3 = Group<C3>.instance.componentList;
		List<C4> c4 = Group<C4>.instance.componentList;

		var entities1 = from c in c1
			select c.entity;
		var entities2 = from c in c2
			select c.entity;
		var entities3 = from c in c3
			select c.entity;
		var entities4 = from c in c4
			select c.entity;
		
		var entities = entities1.Intersect(entities2).Intersect(entities3).Intersect(entities4);

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
				UpdateSystem(process.c1, process.c2, process.c3, process.c4);
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
				FixedUpdateSystem(process.c1, process.c2, process.c3, process.c4);
			}
		}
	}

	public virtual void UpdateSystem(C1 c1, C2 c2, C3 c3, C4 c4)
	{}

	public virtual void FixedUpdateSystem(C1 c1, C2 c2, C3 c3, C4 c4)
	{}

	public void ProcessComponents(Action<C1, C2, C3, C4> callback)
	{
		for (int i = 0; i < processor.Count; ++i)
		{
			var process = processor[i];
			callback(process.c1, process.c2, process.c3, process.c4);
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
