using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

// not prefacing with "I" because I'm using these as tags not interfaces
interface UpdateSystem{}
interface FixedUpdateSystem{}

namespace SimpleECS.Internal
{
	public interface IEntityCount	// just a way to mark the systems with this property, only used in EntityManagerInspector
	{
		int GetEntityCount();
	}

	public abstract class BaseEntitySystem : MonoBehaviour // All systems inherit this so I can group them and add functionality to all of them later if I need to
	{
		
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

	bool _isActive;							// the built in enable flag is a bit unreliable so rolling my own bool
	Action OnEnableCallback = delegate {};	// I use these callbacks to automatically assign and remove entity events
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

		EntityManager.instance.Systems.Add(this);	// This is only for Inspector purposes
		InitializeSystem();

		// add updates to entity manager callbacks
		if (this is UpdateSystem) EntityManager.instance.UpdateCallback += _ProcessUpdate;				// Add to Update if tagged as Update
		if (this is FixedUpdateSystem) EntityManager.instance.FixedUpdateCallback += _ProcessFixedUpdate;	// Add to fixed Update if tagged as fixed update
	}

	void OnDestroy()
	{
		if (!EntityManager.loaded) return; 			// early out if no Entity Manager
		EntityManager.instance.Systems.Remove(this);
		OnEnableCallback = null;								// clear out the delegates on Destroy, makes sure there are no references keeping this alive
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



