using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SimpleECS.Internal;

public abstract class EntitySystem : MonoBehaviour
{
	bool _active;

	Action _OnEnableCallback;
	Action _OnDisableCallback;
	Action _OnInitializeCallback;

	Action _UpdateCallback;
	Action _FixedUpdateCallback;

	#if UNITY_EDITOR
	EntitySystemInfo info = new EntitySystemInfo();
	#endif

	public virtual void Initialize(){}

	/// <summary>
	/// Changes the tooltip displayed when hovering the system in the Entity Manager Inspector
	/// \n creates new line
	/// </summary>
	public virtual string Tooltip()
	{
		return string.Format("Click to Hightlight System in Heirachy");
	}

	void Awake()
	{
		Initialize();
		if (_OnInitializeCallback != null)
			_OnInitializeCallback();

		if (_UpdateCallback != null)
			EntityManager.instance.UpdateCallback += _UpdateSystem;

		if (_FixedUpdateCallback != null)
			EntityManager.instance.FixedUpdateCallback += _FixedUpdateSystem;

		#if UNITY_EDITOR
		info.System = this;
		EntityManager.instance.SystemsInfo.Add(info);
		#endif
	}

	void OnDestroy()
	{
		if (_UpdateCallback != null)
			EntityManager.instance.UpdateCallback -= _UpdateSystem;

		if (_FixedUpdateCallback != null)
			EntityManager.instance.FixedUpdateCallback -= _FixedUpdateSystem;

		#if UNITY_EDITOR
		EntityManager.instance.SystemsInfo.Remove(info);
		#endif
	}

	void OnEnable()
	{
		_active = true;
		if (_OnEnableCallback != null)
			_OnEnableCallback();
	}

	void OnDisable()
	{
		_active = false;
		if (_OnDisableCallback != null)
			_OnDisableCallback();
	}
		
	void _UpdateSystem()
	{
		#if UNITY_EDITOR
		info.StartUpdateTimer();
		#endif

		if (_active)
		{
			_UpdateCallback();	
		}

		#if UNITY_EDITOR
		info.StopUpdateTimer();
		#endif
	}

	void _FixedUpdateSystem()
	{
		#if UNITY_EDITOR
		info.StartFixedUpdateTimer();
		#endif

		if (_active)
		{
			_FixedUpdateCallback();
		}

		#if UNITY_EDITOR
		info.StopFixedUpdateTimer();
		#endif
	}

	/// <summary>
	/// Callback is performed when event is sent to entity
	/// </summary>
	public void AddEntityEvent<E>(EntityEvent<E> action)
	{
		#if UNITY_EDITOR
		info.EntityEvents.Add(typeof(E));
		#endif

		_OnEnableCallback += () => EntityManager.instance.AddEntityEvent<E>(action);
		_OnDisableCallback += () => EntityManager.instance.RemoveEntityEvent<E>(action);
	}

	/// <summary>
	/// Listens for event from all systems
	/// </summary>
	public void AddSystemEvent<E>(Action<E> action)
	{
		#if UNITY_EDITOR
		info.SystemEvents.Add(typeof(E));
		#endif
		_OnEnableCallback += () => EntityManager.instance.AddSystemEvent<E>(action);
		_OnDisableCallback += () => EntityManager.instance.RemoveSystemEvent<E>(action);
	}

	/// <summary>
	/// Send Event to all listening systems
	/// </summary>
	public void SendSystemEvent<E>(E args)
	{
		EntityManager.instance.CallSystemEvent(args);
	}

	#region EnableGroup

	/// <summary>
	/// Performs action once entity contains enabled component
	/// </summary>
	public void AddEnableGroupEvent<C1>(Action<C1> action)
		where C1 : EntityComponent<C1>
	{
		#if UNITY_EDITOR
		info.AddGroupEvents.Add(typeof(Group<C1>));
		#endif

		_OnInitializeCallback += () => ProcessGroup<C1>(action);
		_OnEnableCallback += () => Group<C1>.instance.EnableComponentCallback += action;
		_OnDisableCallback += () => Group<C1>.instance.EnableComponentCallback -= action;
	}

	/// <summary>
	/// Performs action once entity contains all enabled components
	/// </summary>
	public void AddEnableGroupEvent<C1,C2>(Action<C1,C2> action)
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
	{
		#if UNITY_EDITOR
		info.AddGroupEvents.Add(typeof(Group<C1,C2>));
		#endif

		_OnInitializeCallback += () => ProcessGroup<C1,C2>(action);
		_OnEnableCallback += () => Group<C1,C2>.instance.AddGroupCallback += action;
		_OnDisableCallback += () => Group<C1,C2>.instance.AddGroupCallback -= action;
	}

	/// <summary>
	/// Performs action once entity contains all enabled components
	/// </summary>
	public void AddEnableGroupEvent<C1,C2,C3>(Action<C1,C2,C3> action)
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
		where C3 : EntityComponent<C3>
	{
		#if UNITY_EDITOR
		info.AddGroupEvents.Add(typeof(Group<C1,C2,C3>));
		#endif

		_OnInitializeCallback += () => ProcessGroup<C1,C2,C3>(action);
		_OnEnableCallback += () => Group<C1,C2,C3>.instance.AddGroupCallback += action;
		_OnDisableCallback += () => Group<C1,C2,C3>.instance.AddGroupCallback -= action;
	}

	/// <summary>
	/// Performs action once entity contains all enabled components
	/// </summary>
	public void AddEnableGroupEvent<C1,C2,C3,C4>(Action<C1,C2,C3,C4> action)
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
		where C3 : EntityComponent<C3>
		where C4 : EntityComponent<C4>
	{
		#if UNITY_EDITOR
		info.AddGroupEvents.Add(typeof(Group<C1,C2,C3,C4>));
		#endif

		_OnInitializeCallback += () => ProcessGroup<C1,C2,C3,C4>(action);
		_OnEnableCallback += () => Group<C1,C2,C3,C4>.instance.AddGroupCallback += action;
		_OnDisableCallback += () => Group<C1,C2,C3,C4>.instance.AddGroupCallback -= action;
	}

	/// <summary>
	/// Performs action once entity contains all enabled components
	/// </summary>
	public void AddEnableGroupEvent<C1,C2,C3,C4,C5>(Action<C1,C2,C3,C4,C5> action)
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
		where C3 : EntityComponent<C3>
		where C4 : EntityComponent<C4>
		where C5 : EntityComponent<C5>
	{
		#if UNITY_EDITOR
		info.AddGroupEvents.Add(typeof(Group<C1,C2,C3,C4,C5>));
		#endif

		_OnInitializeCallback += () => ProcessGroup<C1,C2,C3,C4,C5>(action);
		_OnEnableCallback += () => Group<C1,C2,C3,C4,C5>.instance.AddGroupCallback += action;
		_OnDisableCallback += () => Group<C1,C2,C3,C4,C5>.instance.AddGroupCallback -= action;
	}

	#endregion

	#region DisableGroup

	/// <summary>
	/// Performs action when entity no longer contains enabled component
	/// </summary>
	public void AddDisableGroupEvent<C1>(Action<C1> action)
		where C1 : EntityComponent<C1>
	{
		#if UNITY_EDITOR
		info.RemoveGroupEvents.Add(typeof(Group<C1>));
		#endif

		_OnEnableCallback += () => Group<C1>.instance.DisableComponentCallback += action;
		_OnDisableCallback += () => Group<C1>.instance.DisableComponentCallback -= action;
	}

	/// <summary>
	/// Performs action when entity no longer contains all enabled components
	/// </summary>
	public void AddDisableGroupEvent<C1,C2>(Action<C1,C2> action)
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
	{
		#if UNITY_EDITOR
		info.RemoveGroupEvents.Add(typeof(Group<C1,C2>));
		#endif

		_OnEnableCallback += () => Group<C1,C2>.instance.RemoveGroupCallback += action;
		_OnDisableCallback += () => Group<C1,C2>.instance.RemoveGroupCallback -= action;
	}

	/// <summary>
	/// Performs action when entity no longer contains all enabled components
	/// </summary>
	public void AddDisableGroupEvent<C1,C2,C3>(Action<C1,C2,C3> action)
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
		where C3 : EntityComponent<C3>
	{
		#if UNITY_EDITOR
		info.RemoveGroupEvents.Add(typeof(Group<C1,C2,C3>));
		#endif

		_OnEnableCallback += () => Group<C1,C2,C3>.instance.RemoveGroupCallback += action;
		_OnDisableCallback += () => Group<C1,C2,C3>.instance.RemoveGroupCallback -= action;
	}

	/// <summary>
	/// Performs action when entity no longer contains all enabled components
	/// </summary>
	public void AddDisableGroupEvent<C1,C2,C3,C4>(Action<C1,C2,C3,C4> action)
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
		where C3 : EntityComponent<C3>
		where C4 : EntityComponent<C4>
	{
		#if UNITY_EDITOR
		info.RemoveGroupEvents.Add(typeof(Group<C1,C2,C3,C4>));
		#endif

		_OnEnableCallback += () => Group<C1,C2,C3,C4>.instance.RemoveGroupCallback += action;
		_OnDisableCallback += () => Group<C1,C2,C3,C4>.instance.RemoveGroupCallback -= action;
	}

	/// <summary>
	/// Performs action when entity no longer contains all enabled components
	/// </summary>
	public void AddDisableGroupEvent<C1,C2,C3,C4,C5>(Action<C1,C2,C3,C4,C5> action)
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
		where C3 : EntityComponent<C3>
		where C4 : EntityComponent<C4>
		where C5 : EntityComponent<C5>
	{
		#if UNITY_EDITOR
		info.RemoveGroupEvents.Add(typeof(Group<C1,C2,C3,C4,C5>));
		#endif

		_OnEnableCallback += () => Group<C1,C2,C3,C4,C5>.instance.RemoveGroupCallback += action;
		_OnDisableCallback += () => Group<C1,C2,C3,C4,C5>.instance.RemoveGroupCallback -= action;
	}

	#endregion

	#region Update

	/// <summary>
	/// Performs action every update
	/// </summary>
	public void AddUpdate(Action action)
	{
		#if UNITY_EDITOR
		info.isUpdateSystem = true;
		#endif
		_UpdateCallback += action;
	}

	/// <summary>
	/// Performs action every update on entities that contains all components
	/// </summary>
	public void AddUpdate<C1>(Action<C1> action)
		where C1: EntityComponent<C1>
	{
		#if UNITY_EDITOR
		info.isUpdateSystem = true;
		info.UpdateTypes.Add(typeof(Group<C1>));
		#endif

		_UpdateCallback += () => ProcessGroup<C1>(action);
	}

	/// <summary>
	/// Performs action every update on entities that contains all components
	/// </summary>
	public void AddUpdate<C1, C2>(Action<C1, C2> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
	{
		#if UNITY_EDITOR
		info.isUpdateSystem = true;
		info.UpdateTypes.Add(typeof(Group<C1,C2>));
		#endif

		_UpdateCallback += () => ProcessGroup<C1,C2>(action);
	}

	/// <summary>
	/// Performs action every update on entities that contains all components
	/// </summary>
	public void AddUpdate<C1,C2,C3>(Action<C1,C2,C3> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
		where C3: EntityComponent<C3>
	{
		#if UNITY_EDITOR
		info.isUpdateSystem = true;
		info.UpdateTypes.Add(typeof(Group<C1,C2,C3>));
		#endif

		_UpdateCallback += () => ProcessGroup<C1,C2,C3>(action);
	}

	/// <summary>
	/// Performs action every update on entities that contains all components
	/// </summary>
	public void AddUpdate<C1,C2,C3,C4>(Action<C1,C2,C3,C4> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
		where C3: EntityComponent<C3>
		where C4: EntityComponent<C4>
	{
		#if UNITY_EDITOR
		info.isUpdateSystem = true;
		info.UpdateTypes.Add(typeof(Group<C1,C2,C3,C4>));
		#endif

		_UpdateCallback += () => ProcessGroup<C1,C2,C3,C4>(action);
	}

	/// <summary>
	/// Performs action every update on entities that contains all components
	/// </summary>
	public void AddUpdate<C1,C2,C3,C4,C5>(Action<C1,C2,C3,C4,C5> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
		where C3: EntityComponent<C3>
		where C4: EntityComponent<C4>
		where C5: EntityComponent<C5>
	{
		#if UNITY_EDITOR
		info.isUpdateSystem = true;
		info.UpdateTypes.Add(typeof(Group<C1,C2,C3,C4,C5>));
		#endif

		_UpdateCallback += () => ProcessGroup<C1,C2,C3,C4,C5>(action);
	}

	#endregion

	#region fixedUpdate

	/// <summary>
	/// Performs action every fixed update
	/// </summary>
	public void AddFixedUpdate(Action action)
	{		
		#if UNITY_EDITOR
		info.isFixedUpdateSystem = true;
		#endif

		_FixedUpdateCallback += action;
	}

	/// <summary>
	/// Performs action every fixed update on entities that contains component
	/// </summary>
	public void AddFixedUpdate<C1>(Action<C1> action)
		where C1: EntityComponent<C1>
	{		
		#if UNITY_EDITOR
		info.isFixedUpdateSystem = true;
		info.FixedUpdateTypes.Add(typeof(Group<C1>));
		#endif

		_FixedUpdateCallback += () => ProcessGroup<C1>(action);
	}

	/// <summary>
	/// Performs action every fixed update on entities that contains all components
	/// </summary>
	public void AddFixedUpdate<C1, C2>(Action<C1, C2> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
	{		
		#if UNITY_EDITOR
		info.isFixedUpdateSystem = true;
		info.FixedUpdateTypes.Add(typeof(Group<C1,C2>));
		#endif

		_FixedUpdateCallback += () => ProcessGroup<C1,C2>(action);
	}

	/// <summary>
	/// Performs action every fixed update on entities that contains all components
	/// </summary>
	public void AddFixedUpdate<C1,C2,C3>(Action<C1,C2,C3> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
		where C3: EntityComponent<C3>
	{		
		#if UNITY_EDITOR
		info.isFixedUpdateSystem = true;
		info.FixedUpdateTypes.Add(typeof(Group<C1,C2,C3>));
		#endif

		_FixedUpdateCallback += () => ProcessGroup<C1,C2,C3>(action);
	}

	/// <summary>
	/// Performs action every fixed update on entities that contains all components
	/// </summary>
	public void AddFixedUpdate<C1,C2,C3,C4>(Action<C1,C2,C3,C4> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
		where C3: EntityComponent<C3>
		where C4: EntityComponent<C4>
	{		
		#if UNITY_EDITOR
		info.isFixedUpdateSystem = true;
		info.FixedUpdateTypes.Add(typeof(Group<C1,C2,C3,C4>));
		#endif

		_FixedUpdateCallback += () => ProcessGroup<C1,C2,C3,C4>(action);
	}

	/// <summary>
	/// Performs action every fixed update on entities that contains all components
	/// </summary>
	public void AddFixedUpdate<C1,C2,C3,C4,C5>(Action<C1,C2,C3,C4,C5> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
		where C3: EntityComponent<C3>
		where C4: EntityComponent<C4>
		where C5: EntityComponent<C5>
	{		
		#if UNITY_EDITOR
		info.isFixedUpdateSystem = true;
		info.FixedUpdateTypes.Add(typeof(Group<C1,C2,C3,C4,C5>));
		#endif

		_FixedUpdateCallback += () => ProcessGroup<C1,C2,C3,C4,C5>(action);
	}

	#endregion

	#region ProcessGroup

	/// <summary>
	/// Does action on all entities which contains all specified components
	/// </summary>
	public void ProcessGroup<C1>(Action<C1> action)
		where C1: EntityComponent<C1>
	{
		var Group = Group<C1>.instance.components;
		var count = Group<C1>.instance.ComponentCount;
		for (int i = 0; i < count; ++i)
			action(Group[i]);
	}

	/// <summary>
	/// Does action on all entities which contains all specified components
	/// </summary>
	public void ProcessGroup<C1,C2>(Action<C1,C2> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
	{
		var Group = Group<C1,C2>.instance.processors;
		var count = Group<C1,C2>.instance.processorCount;
		for (int i = 0; i < count; ++i)
		{
			var p = Group[i];
			action(p.c1, p.c2);	
		}
	}

	/// <summary>
	/// Does action on all entities which contains all specified components
	/// </summary>
	public void ProcessGroup<C1,C2,C3>(Action<C1,C2,C3> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
		where C3: EntityComponent<C3>
	{
		var Group = Group<C1,C2,C3>.instance.processors;
		var count = Group<C1,C2,C3>.instance.processorCount;
		for (int i = 0; i < count; ++i)
		{
			var p = Group[i];
			action(p.c1, p.c2, p.c3);	
		}
	}

	/// <summary>
	/// Does action on all entities which contains all specified components
	/// </summary>
	public void ProcessGroup<C1,C2,C3,C4>(Action<C1,C2,C3,C4> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
		where C3: EntityComponent<C3>
		where C4: EntityComponent<C4>
	{
		var Group = Group<C1,C2,C3,C4>.instance.processors;
		var count = Group<C1,C2,C3,C4>.instance.processorCount;
		for (int i = 0; i < count; ++i)
		{
			var p = Group[i];
			action(p.c1, p.c2, p.c3, p.c4);	
		}
	}

	/// <summary>
	/// Does action on all entities which contains all specified components
	/// </summary>
	public void ProcessGroup<C1,C2,C3,C4,C5>(Action<C1,C2,C3,C4,C5> action)
		where C1: EntityComponent<C1>
		where C2: EntityComponent<C2>
		where C3: EntityComponent<C3>
		where C4: EntityComponent<C4>
		where C5: EntityComponent<C5>
	{
		var Group = Group<C1,C2,C3,C4,C5>.instance.processors;
		var count = Group<C1,C2,C3,C4,C5>.instance.processorCount;
		for (int i = 0; i < count; ++i)
		{
			var p = Group[i];
			action(p.c1, p.c2, p.c3, p.c4, p.c5);	
		}
	}

	#endregion
}
