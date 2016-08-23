using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using ECS.Internal;
using System;

namespace ECS
{
	public interface IUpdateSystem{}	// Update EveryFrame

	[System.Serializable]
	public class EntitySystem
	{
		bool _enabled = false;
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ECS.EntitySystem"/> is enabled.
		/// </summary>
		public bool enabled
		{
			get {return _enabled;}
			set
			{
				if (_enabled)
				{
					if (value == false)
						OnDisable();
				}
				else
				{
					if (value == true)
						OnEnable();
				}
				_enabled = value;
			}
		}

		/// <summary>
		/// Gets called once when system is created regardless if enabled or not.
		/// Gets called before OnEnable()
		/// </summary>
		public virtual void SetGroups(){}

		/// <summary>
		/// Process Update Systems.
		/// Must implement IUpdateSystem interface to use.
		/// </summary>
		public virtual void Update(){}

		/// <summary>
		/// Gets called when system is enabled
		/// </summary>
		public virtual void OnEnable(){}

		/// <summary>
		/// gets called when system is disabled
		/// </summary>
		public virtual void OnDisable(){}
	}

	[System.Serializable]
	public class EntitySystemManager
	{
		static Dictionary<Type, EntitySystem> _systemLookup = new Dictionary<Type, EntitySystem>();					// System Lookup
		static List<EntitySystem> _updateSystems = new List<EntitySystem>();										// list of update systems																						// if set to false, system manager stops updates
		public static List<EntitySystem> _systems = new List<EntitySystem>();										// List of systems in system Manager, mainly for Inspector

		public EntitySystemManager(params EntitySystem[] system)
		{
			for(int i = 0; i < system.Length; ++i)
			{
				Add(system[i]);
			}
		}

		/// <summary>
		/// Add the specified system. Can string adding systems together
		/// </summary>
		public EntitySystemManager Add(EntitySystem system)
		{
			return Add(system, true);
		}

		/// <summary>
		/// Add the specified system and sets if enabled.
		/// </summary>
		public EntitySystemManager Add(EntitySystem system, bool setEnabled)
		{
			if (_systemLookup.ContainsKey(system.GetType()))	// Only allowing 1 instance of a system since a system manipulates all components. Systems will update components irrespective of managers
			{
				#if UNITY_EDITOR
				Debug.LogError(string.Format("{0} already exsits in {1}. Can only have 1 instance of system in Manager", system.GetType()));
				#endif
				return this;
			}
			_systemLookup.Add(system.GetType(), system);
			_systems.Add(system);
			if (system is IUpdateSystem)
			{
				_updateSystems.Add(system);
			}
			system.SetGroups();
			system.enabled = setEnabled;
			return this;
		}

		/// <summary>
		/// Sets whether system is enabled
		/// </summary>
		public EntitySystemManager SetEnabled<C>(bool setEnabled) where C : EntitySystem
		{
			EntitySystem system;
			if (_systemLookup.TryGetValue(typeof(C), out system))
				system.enabled = setEnabled;
			else 
			{
				#if UNITY_EDITOR
				Debug.LogError(string.Format("{0} not found. Add {0} to Event Manager", typeof(C)));
				#endif
			}
			return this;
		}

		public void Start()
		{
			EntityLink[] links = GameObject.FindObjectsOfType<EntityLink>();
			foreach( var link in links)
			{
				link.SetUpComponents();
			}
		}

		/// <summary>
		/// Updates Systems
		/// </summary>
		public void Update()
		{
			for (int i = 0; i < _updateSystems.Count; ++i)	// process all update systems
			{
				if (_updateSystems[i].enabled)
					_updateSystems[i].Update();
			}
		}

		public static int SystemsCount
		{
			get{return _systemLookup.Count;}
		}

		public static int UpdateSystemsCount
		{
			get{return _updateSystems.Count;}
		}

	}
}

