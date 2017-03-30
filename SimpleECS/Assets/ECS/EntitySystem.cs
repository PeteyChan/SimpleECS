using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

namespace SimpleECS.Internal
{
	public interface IEntityCount
	{
		int GetEntityCount();
	}

	public abstract class BaseEntitySystem : MonoBehaviour
	{
		
	}
}

public abstract class EntitySystem : BaseEntitySystem
{
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
		OnEnableCallback();
	}

	void OnDisable()
	{
		_active = false;
		OnDisableCallback();
	}

	void _ProcessUpdate()
	{
		if (_active) UpdateSystem();
	}

	void _ProcessFixedUpdate()
	{
		if (_active) FixedUpdateSystem();
	}

	public virtual void InitializeSystem()
	{}

	public virtual void UpdateSystem()
	{}

	public virtual void FixedUpdateSystem()
	{}

	public void AddEvent<E>(EntityEvent<E> callback)
	{
		OnEnableCallback += () => EntityManager.instance.AddEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveEvent(callback);
	}
}

public abstract class EntitySystem<C> : BaseEntitySystem, IEntityCount
	where C : EntityComponent<C>
{
	List<C> components;

	Action OnEnableCallback = delegate {};
	Action OnDisableCallback = delegate {};

	void Awake()
	{
		EntityManager.instance.Systems.Add(this);
		components = Group<C>.instance.componentList;
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
		OnEnableCallback();
	}

	void OnDisable()
	{
		_active = false;
		OnDisableCallback();
	}

	void _ProcessUpdate()
	{
		if (_active)
		{
			for (int i = 0; i < components.Count; ++i)
			{
				UpdateSystem(components[i]);
			}
		}
	}

	void _ProcessFixedUpdate()
	{
		if (_active)
		{
			for (int i = 0; i < components.Count; ++i)
			{
				FixedUpdateSystem(components[i]);
			}
		}
	}

	/// <summary>
	/// Allows manual processing of compoennts
	/// </summary>
	public void ProcessComponents(Action<C> callback)
	{
		for (int i = 0; i < components.Count; ++i)
		{
			callback(components[i]);
		}
	}

	public void AddEvent<E>(EntityEvent<E> callback)
	{
		OnEnableCallback += () => EntityManager.instance.AddEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveEvent(callback);
	}

	/// <summary>
	/// Returns how many Entities using this System
	/// </summary>
	public int GetEntityCount ()
	{
		return components.Count;
	}

	public virtual void InitializeSystem()
	{}

	public virtual void UpdateSystem(C component)
	{}

	public virtual void FixedUpdateSystem(C component)
	{}

}

