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

	public abstract class BaseEntitySystem : MonoBehaviour // All systems inherit this so I can group them and add functionality to all of them later if I need to
	{
		bool _update,_fixedUpdate,_updateSet,_fixedUpdateSet;
		protected bool isUpdateSystem
		{
			get 
			{
				return _update;
			} 
			set
			{
				if (!_updateSet)
				{
					_update = value;
					_updateSet = true;
				}
			}
		}

		protected bool isFixedUpdateSystem
		{
			get
			{
				return _fixedUpdate;
			}

			set
			{
				if (!_fixedUpdateSet)
				{
					_fixedUpdate = value;
					_fixedUpdateSet = true;
				}
			}
		}
	}
}


/// <summary>
/// Non Component System, used for systems that only have events
/// </summary>
public abstract class EntitySystem : BaseEntitySystem
{
	/// 				///
	///   Properties	///
	/// 				///

	bool _isActive;	// the built in enable flag is a bit unreliable so using my own bool
	Action OnEnableCallback = delegate {};	// I use these callbacks to automatically assign and remove entity events
	Action OnDisableCallback = delegate {};

	/// 				///
	///   Unity Events	///
	/// 				///

	void Awake()
	{
		if (EntityManager.instance == null) // if no EntityManager Destroy System
		{
			Destroy(this);
			return;
		}

		EntityManager.instance.Systems.Add(this);	// This is only for Inspector purposes
		InitializeSystem();

		// set the systems to make sure that they can't change
		isUpdateSystem = isUpdateSystem;
		isFixedUpdateSystem = isFixedUpdateSystem;

		// add updates to entity manager callbacks
		if (isUpdateSystem) EntityManager.instance.UpdateCallback += _ProcessUpdate;				// Add to Update if tagged as Update
		if (isFixedUpdateSystem) EntityManager.instance.FixedUpdateCallback += _ProcessFixedUpdate;	// Add to fixed Update if tagged as fixed update
	}

	void OnDestroy()
	{
		if (EntityManager.instance == null) return; 			// early out if no Entity Manager

		EntityManager.instance.Systems.Remove(this);
		OnEnableCallback = null;								// clear out the delegates on Destroy, makes sure there are no references keeping this alive
		OnDisableCallback = null;
		if (isUpdateSystem) EntityManager.instance.UpdateCallback -= _ProcessUpdate;
		if (isFixedUpdateSystem) EntityManager.instance.FixedUpdateCallback -= _ProcessFixedUpdate;
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
		if (_isActive) UpdateSystem();
	}

	void _ProcessFixedUpdate()
	{
		if (_isActive) FixedUpdateSystem();
	}

	/// 					///
	///   Public Functions	///
	/// 					///

	/// <summary>
	/// Method is Called Only Once during System Instantiation.
	/// This is where you should add all AddEvent Code and set if the system is and Update or FixedUpdate System
	/// </summary>
	public virtual void InitializeSystem()
	{}

	/// <summary>
	/// Updates the system.
	/// </summary>
	public virtual void UpdateSystem()
	{}

	/// <summary>
	/// Does a fixed update on the system.
	/// </summary>
	public virtual void FixedUpdateSystem()
	{}

	/// <summary>
	/// Subscribes Callback to the Event Handler.
	/// Callback will fire on Entity the Event is sent to.
	/// Events should only be added during the Initialize System override. 
	/// Events are automatically added and removed during System enabled or disabled.
	/// </summary>
	public void AddEvent<E>(EntityEvent<E> callback)	// using simple lambda functions to automate adding and removing events
	{
		OnEnableCallback += () => EntityManager.instance.AddEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveEvent(callback);
	}
}



