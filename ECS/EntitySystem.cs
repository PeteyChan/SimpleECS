using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class EntitySystem : MonoBehaviour 
{}

public abstract class EntitySystem<C> : EntitySystem where C : EntityComponent<C>
{
	public int PoolCount;

	List<C> components;

	void Awake()
	{
		if (EntityManager.instance != null)
			components = Group<C>.instance.componentList;
	}

	void OnEnable()
	{
		if (EntityManager.instance != null)
		{
			if (this is IUpdate)
				EntityManager.instance.UpdateCallback += _ProcessUpdate;
			if (this is IFixedUpdate)
				EntityManager.instance.FixedUpdateCallback += _ProcessFixedUpdate;
			SubscribeEvents();
		}
	}

	void OnDisable()
	{
		if (EntityManager.instance != null)
		{
			if (this is IUpdate)
				EntityManager.instance.UpdateCallback -= _ProcessUpdate;
			if (this is IFixedUpdate)
				EntityManager.instance.FixedUpdateCallback -= _ProcessFixedUpdate;
			UnSubscribeEvents();
		}
	}

	public virtual void SubscribeEvents()
	{}

	public virtual void UnSubscribeEvents()
	{}


	void _ProcessUpdate()
	{
		PoolCount = components.Count;

		for (int i = 0; i < components.Count; ++i)
		{
			UpdateSystem(components[i]);
		}
	}

	void _ProcessFixedUpdate()
	{
		for (int i = 0; i < components.Count; ++i)
		{
			FixedUpdateSystem(components[i]);
		}
	}

	public virtual void UpdateSystem(C component)
	{}

	public virtual void FixedUpdateSystem(C component)
	{}

	public void ProcessComponents(Action<C> callback)
	{
		for (int i = 0; i < components.Count; ++i)
		{
			callback(components[i]);
		}
	}

	public void AddEvent<E>(EntityEvent<E> callback)
	{
		EntityManager.instance.AddEvent(callback);
	}

	public void RemoveEvent<E>(EntityEvent<E> callback)
	{
		EntityManager.instance.RemoveEvent(callback);
	}
}

