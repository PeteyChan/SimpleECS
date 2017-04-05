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
	bool _isActive;							// the built in enable flag is a bit unreliable so rolling my own bool
	Action OnEnableCallback = delegate {};	// I use these callbacks to automatically assign and remove entity events
	Action OnDisableCallback = delegate {};

	#if UNITY_EDITOR
		SimpleECS.Internal.SystemInfo info = new SimpleECS.Internal.SystemInfo();
	#endif

	void Awake()
	{
		if (!EntityManager.loaded)
		{
			Debug.Log("Must Add Entity Manager to the Scene to use EntitySystems");
			return;
		}

		#if UNITY_EDITOR	// used for displaying Simple ECS data in Entity Manager
		info.System = this;
		EntityManager.instance.SystemsInfo.Add(info);
		#endif

		InitializeSystem();

		// add updates to entity manager callbacks
		if (this is UpdateSystem) EntityManager.instance.UpdateCallback += _ProcessUpdate;				// Add to Update if tagged as Update
		if (this is FixedUpdateSystem) EntityManager.instance.FixedUpdateCallback += _ProcessFixedUpdate;	// Add to fixed Update if tagged as fixed update
	}

	void OnDestroy()
	{
		if (!EntityManager.loaded) return; 			// early out if no Entity Manager

		#if UNITY_EDITOR
		EntityManager.instance.SystemsInfo.Remove(info);	// remove system from entity manager
		#endif

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
		#if UNITY_EDITOR
		if (info.ShowInfo)
			info.StartUpdateTimer();
		#endif

		if (_isActive) UpdateSystem();

		#if UNITY_EDITOR
		if (info.ShowInfo)
			info.StopUpdateTimer();
		#endif
	}

	void _ProcessFixedUpdate()
	{
		#if UNITY_EDITOR
		if (info.ShowInfo)
			info.StartFixedUpdateTimer();
		#endif

		if (_isActive) FixedUpdateSystem();

		#if UNITY_EDITOR
		if (info.ShowInfo)
			info.StopFixedUpdateTimer();
		#endif
	}

	#region Public Functions

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

	#endregion

	#region SystemEvents

	/// <summary>
	/// Subscribes callback to the Event Handler.
	/// Callback will be invoked when the event is sent to an entity.
	/// Events should only be added during Initialize System. 
	/// Events are automatically added and removed when System is enabled or disabled.
	/// </summary>
	public void AddEntityEvent<E>(EntityEvent<E> callback)	// using simple lambda functions to automate adding and removing events
	{
		OnEnableCallback += () => EntityManager.instance.AddEntityEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveEntityEvent(callback);

		#if UNITY_EDITOR
		info.EntityEvents.Add(typeof(E));
		#endif
	}

	/// <summary>
	/// Subscribes callback to the Event Handler.
	/// Callback will fire when component is enabled.
	/// Events are automatically added and removed when System is enabled or disabled.
	/// </summary>
	public void AddEnableComponentEvent<C>(Action<C> callback) where C : EntityComponent<C>
	{
		OnEnableCallback += () => Group<C>.instance.EnableComponentCallback += callback;
		OnDisableCallback += () => Group<C>.instance.EnableComponentCallback -= callback;

		#if UNITY_EDITOR
		info.EnableComponentEvent.Add(typeof(C));
		#endif
	}

	/// <summary>
	/// Subscribes callback to the Event Handler.
	/// Callback will fire when component is disabled.
	/// Events are automatically added and removed when System is enabled or disabled.
	/// </summary>
	public void AddDisableComponentEvent<C>(Action<C> callback) where C : EntityComponent<C>
	{
		OnEnableCallback += () => Group<C>.instance.DisableComponentCallback += callback;
		OnDisableCallback += () => Group<C>.instance.DisableComponentCallback -= callback;

		#if UNITY_EDITOR
		info.DisableComponentEvent.Add(typeof(C));
		#endif
	}

	/// <summary>
	/// Subscribes callback to the Event Handler.
	/// Callback will fire on when a System Sends the Event.
	/// Events are automatically added and removed when System is enabled or disabled.
	/// </summary>
	public void AddSystemEvent<E>(Action<E> callback)
	{
		OnEnableCallback += () => EntityManager.instance.AddSystemEvent(callback);
		OnDisableCallback += () => EntityManager.instance.RemoveSystemEvent(callback);

		#if UNITY_EDITOR
		info.SystemEvents.Add(typeof(E));
		#endif
	}

	/// <summary>
	/// Call the Event on all subscribed systems with specified arguments.
	/// </summary>
	public void SendSystemEvent<E>(E args)
	{
		EntityManager.instance.CallSystemEvent(args);
	}

	#endregion

}



