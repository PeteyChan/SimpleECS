using System.Collections.Generic;
using System;
using ECS.Internal;
using UnityEngine;

namespace ECS
{
	[System.Serializable]
	public class EntitySystemManager
	{
		static Dictionary<Type, EntitySystem> _systemLookup = new Dictionary<Type, EntitySystem>();					// System Lookup
		static List<EntitySystem> _updateSystems = new List<EntitySystem>();								// List of systems in system Manager, mainly for Inspector
		static List<EntitySystem> _fixedUpdateSystems = new List<EntitySystem>();
		static Dictionary <string, SystemGroup> _systemGroups	// moved out of this class so it's not exposed
		{
			get
			{
				return ECSManager._systemGroups;
			}
		}

		const string DefaultGroup = "Default";

		/// <summary>
		/// Add the specified system. Can string adding systems together
		/// </summary>
		public EntitySystemManager Add(EntitySystem system)
		{
			return Add(DefaultGroup, system, true);
		}
			
		/// <summary>
		/// Add the specified system and sets if enabled.
		/// </summary>
		public EntitySystemManager Add(EntitySystem system, bool setEnabled)
		{
			return Add(DefaultGroup, system, setEnabled);
		}

		/// <summary>
		/// Add the specified system to Group.
		/// </summary>
		public EntitySystemManager Add(string Group, EntitySystem system)
		{
			return Add(Group, system, true);
		}

		/// <summary>
		/// Add the specified system to Group and sets enabled.
		/// </summary>
		public EntitySystemManager Add(string groupName, EntitySystem system, bool setEnabled)
		{
			if (_systemLookup.ContainsKey(system.GetType()))	// Only allowing 1 instance of a system since a system manipulates all components. Systems will update components irrespective of managers
			{
				#if UNITY_EDITOR
				Debug.LogError(string.Format("{0} already exsits in {1}. Can only have 1 instance of system in Manager", system.GetType()));
				#endif
				return this;	// early out if already added
			}

			_systemLookup[system.GetType()] = system;

			if (!string.IsNullOrEmpty(groupName))		 // add default group
			{
				SystemGroup systemGroup;
				if (!_systemGroups.ContainsKey(groupName))	// if group not found make a new one
				{
					systemGroup = new SystemGroup();
					systemGroup.name = groupName;
					_systemGroups[groupName] = systemGroup;
				}
				_systemGroups[groupName].systems.Add(system); // add system to group
			}
				
			if (system is IUpdate)	// add system to update list
			{
				_updateSystems.Add(system);
			}
			if (system is IFixedUpdate)
			{
				_fixedUpdateSystems.Add(system);
			}

			system.SetGroups();				// fire system initializers
			system.enabled = setEnabled;
			return this;
		}
			
		/// <summary>
		/// Sets whether system is enabled
		/// </summary>
		public static void SetEnabled<C>(bool setEnabled) where C: EntitySystem
		{
			EntitySystem system;
			if (_systemLookup.TryGetValue(typeof(C), out system))
			{
				system.enabled = setEnabled;
			}
			else 
			{
				#if UNITY_EDITOR
				Debug.LogError(string.Format("{0} not found. Add {0} to Event Manager", typeof(C)));
				#endif
			}
		}

		public static List<EntitySystem> GetSystemGroup (string name)
		{
			SystemGroup systemGroup;
			if (_systemGroups.TryGetValue(name, out systemGroup))
			{
				return systemGroup.systems;
			}
			#if UNITY_EDITOR
			Debug.Log(string.Format("{0} system group does not exist", name));
			#endif
			return null;
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

		public void FixedUpdate()
		{
			for (int i = 0; i < _fixedUpdateSystems.Count; ++i)	// process all update systems
			{
				if (_fixedUpdateSystems[i].enabled)
					_fixedUpdateSystems[i].FixedUpdate();
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

		public static int FixedUpdateSystemsCount
		{
			get{return _fixedUpdateSystems.Count;}
		}
	}
}

namespace ECS.Internal
{
	public class SystemGroup
	{
		public string name;
		public List<EntitySystem> systems = new List<EntitySystem>();
		public bool enabled = false;
	}
}