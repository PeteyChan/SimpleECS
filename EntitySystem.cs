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
		public EntitySystemManager(string name)
		{
			SetName(name);	
		}
		static Dictionary<string, EntitySystemManager> systemManagers = new Dictionary<string, EntitySystemManager>();	// keeps track if multiple system managers
		static Dictionary<Type, EntitySystem> _systemLookup = new Dictionary<Type, EntitySystem>();	// System Lookup
		List<EntitySystem> _updateSystems = new List<EntitySystem>();	// list of update systems
		bool _stopped = false;	// if set to false, system manager stops updates

		public List<EntitySystem> Systems = new List<EntitySystem>();	// List of systems, mainly for Inspector


		public EntitySystemManager(string name, params EntitySystem[] system)
		{
			SetName(name);
			for(int i = 0; i < system.Length; ++i)
			{
				Add(system[i]);
			}
		}

		void SetName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("System Manager needs to be named");
			}
			if (systemManagers.ContainsKey(name))
			{
				throw new Exception("Cannot have system managers with same name");
			}
			systemManagers.Add(name, this);
			_name = name;
		}

		string _name;	// name of EntitySystem;
		public string Name
		{
			get {return _name;}
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
				Debug.LogError(string.Format("{0} already exsits. Can only have 1 instance of system across all managers", system.GetType(), Name));
				#endif
				return this;
			}
			_systemLookup.Add(system.GetType(), system);
			Systems.Add(system);
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
				Debug.LogError(string.Format("System not found in {0} manager.", Name));
				#endif
			}
			return this;
		}

		/// <summary>
		/// Stops all update systems
		/// </summary>
		public static void StopManager(string name)
		{
			EntitySystemManager manager;
			if (systemManagers.TryGetValue(name, out manager))
			{
				manager.Stop();
			}
		}
		
		/// <summary>
		/// Resumes all update systems
		/// </summary>
		public static void ResumeManager(string name)
		{
			EntitySystemManager manager;
			if (systemManagers.TryGetValue(name, out manager))
			{
				manager.Resume();
			}
		}

		/// <summary>
		/// Stops All update Systems
		/// </summary>
		public void Stop()
		{
			_stopped = true;
		}

		/// <summary>
		/// Resumes All update Systems
		/// </summary>
		public void Resume()
		{
			_stopped = false;
		}

		/// <summary>
		/// Updates Systems
		/// </summary>
		public void Update()
		{
			if (_stopped)
				return;

			for (int i = 0; i < _updateSystems.Count; ++i)
			{
				if (_updateSystems[i].enabled)
					_updateSystems[i].Update();
			}
		}

		public int SystemsCount
		{
			get{return _systemLookup.Count;}
		}

		public int UpdateSystemsCount
		{
			
			get
			{
				if (string.IsNullOrEmpty(Name))
				{
					return 0;
				}
				return _updateSystems.Count;
			}
		}

	}
}

