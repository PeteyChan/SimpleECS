using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

namespace SimpleECS.Internal
{
	public interface IEntityCount	// just a way to mark the systems with this property, only used in EntityManagerInspector
	{
		int GetEntityCount();
	}

	public abstract class BaseEntitySystem : MonoBehaviour // All systems inherit this so I can group them and add functionality to all of them if I need to
	{}
}

public abstract class EntitySystem : BaseEntitySystem
{
	Action OnEnableCallback = delegate {};	// I use these callbacks to automatically assign and remove
	Action OnDisableCallback = delegate {};	// event callbacks

	void Awake()
	{
		EntityManager.instance.Systems.Add(this);	// This is only for Inspector purposes
		InitializeSystem();
		if (this is IUpdate) EntityManager.instance.UpdateCallback += _ProcessUpdate;		// Add to Update if tagged as Update
		if (this is IFixedUpdate) EntityManager.instance.FixedUpdateCallback += _ProcessFixedUpdate;	// Add to fixed Update if tagged as fixed update
	}

	void OnDestroy()
	{
		EntityManager.instance.Systems.Remove(this);
		OnEnableCallback = null;	// clear out the delegates on Destroy, makes sure there are no references keeping this alive
		OnDisableCallback = null;
		if (this is IUpdate) EntityManager.instance.UpdateCallback -= _ProcessUpdate;
		if (this is IFixedUpdate) EntityManager.instance.FixedUpdateCallback -= _ProcessFixedUpdate;
	}

	bool _active;	// the built in enable flag is a bit unreliable so using my own bool
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

	/// <summary>
	/// Method is Called Only Once during System Instantiation.
	/// This is where you should add all AddEvent Code
	/// </summary>
	public virtual void InitializeSystem()
	{}

	public virtual void UpdateSystem()
	{}

	public virtual void FixedUpdateSystem()
	{}

	/// <summary>
	/// Subscribes Callback to the Event Handler.
	/// Events are automatically added and removed when System is enabled or disabled
	/// </summary>
	public void AddEvent<E>(EntityEvent<E> callback)	// using simple lambda functions to automate adding and removing events
	{
		OnEnableCallback += () => EntityManager.instance.AddEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveEvent(callback);
	}
}

public abstract class EntitySystem<C> : BaseEntitySystem, IEntityCount
	where C : EntityComponent<C>
{
	List<C> components;	// single component systems acutally share component lists

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
	/// Allows manual processing of components
	/// Callback must match the Update signature
	/// </summary>
	public void ProcessComponents(Action<C> callback)
	{
		for (int i = 0; i < components.Count; ++i)
		{
			callback(components[i]);
		}
	}


	/// <summary>
	/// Subscribes Callback to the Event Handler.
	/// Events are automatically added and removed when System is enabled or disabled
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
		return components.Count;
	}

	/// <summary>
	/// Method is Called Only Once during System Instantiation.
	/// This is where you should add all AddEvent Code
	/// </summary>
	public virtual void InitializeSystem()
	{}

	public virtual void UpdateSystem(C component)
	{}

	public virtual void FixedUpdateSystem(C component)
	{}

}

