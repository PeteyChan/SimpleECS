using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class EntitySystem : MonoBehaviour 
{
	void Awake()
	{
		InitializeSystem();
	}

	void OnEnable()
	{
		if (EntityManager.instance != null)
		{
			if (this is IUpdate)
				EntityManager.instance.UpdateCallback += UpdateSystem;
			if (this is IFixedUpdate)
				EntityManager.instance.FixedUpdateCallback += FixedUpdateSystem;
		}
		OnEnableCallback();
	}

	void OnDisable()
	{
		if (EntityManager.instance != null)
		{
			if (this is IUpdate)
				EntityManager.instance.UpdateCallback -= UpdateSystem;
			if (this is IFixedUpdate)
				EntityManager.instance.FixedUpdateCallback -= FixedUpdateSystem;
		}
		OnDisableCallback();
	}

	public virtual void UpdateSystem()
	{}

	public virtual void FixedUpdateSystem()
	{}

	public virtual void InitializeSystem()
	{}

	Action OnEnableCallback = delegate {};
	Action OnDisableCallback = delegate {};

	public void AddEvent<E>(EntityEvent<E> callback)
	{
		OnEnableCallback += () => EntityManager.instance.AddEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveEvent(callback);
	}
}

public abstract class EntitySystem<C> : MonoBehaviour where C : EntityComponent<C>
{
	List<C> components;

	void Awake()
	{
		if (EntityManager.instance != null)
			components = Group<C>.instance.componentList;
		InitializeSystem();
	}

	void OnEnable()
	{
		if (EntityManager.instance != null)
		{
			if (this is IUpdate)
				EntityManager.instance.UpdateCallback += _ProcessUpdate;
			if (this is IFixedUpdate)
				EntityManager.instance.FixedUpdateCallback += _ProcessFixedUpdate;
		}
		OnEnableCallback();
	}

	void OnDisable()
	{
		if (EntityManager.instance != null)
		{
			if (this is IUpdate)
				EntityManager.instance.UpdateCallback -= _ProcessUpdate;
			if (this is IFixedUpdate)
				EntityManager.instance.FixedUpdateCallback -= _ProcessFixedUpdate;
		}
		OnDisableCallback();
	}

	void _ProcessUpdate()
	{
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

	/// <summary>
	/// Returns how many Entities using this System
	/// </summary>
	public int EntityCount
	{
		get {return components.Count;}
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
}

