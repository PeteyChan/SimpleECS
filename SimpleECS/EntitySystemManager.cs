using System.Collections.Generic;
using System;
using ECS.Internal;
using UnityEngine;

namespace ECS
{
	/// <summary>
	/// Interface for Entity Systems
	/// </summary>
	[System.Serializable]
	public static class EntitySystemManager
	{
		static EntitySystemManager()
		{
			ECSManager.LoadSceneEvent += OnLoadScene;
		}

		static EntitySystems _systems;
		static EntitySystems systems
		{
			get 
			{
				if (_systems == null)
				{
					_systems = new GameObject("Entity Systems Inspector").AddComponent<EntitySystems>();
				}
				return _systems;
			}
		}

		/// <summary>
		/// Add the specified system. Can string adding systems together
		/// </summary>
		public static EntitySystems Add(EntitySystem system)
		{
			return systems.Add(system);
		}

		/// <summary>
		/// Add the specified system and sets if enabled.
		/// </summary>
		public static EntitySystems Add(EntitySystem system, bool setEnabled)
		{
			return systems.Add(system, setEnabled);
		}

		/// <summary>
		/// Add the specified system to Group.
		/// </summary>
		public static EntitySystems Add(string groupName, EntitySystem system)
		{
			return systems.Add(groupName, system);
		}

		/// <summary>
		/// Add the specified system to Group and sets enabled.
		/// </summary>
		public static EntitySystems Add(string groupName, EntitySystem system, bool setEnabled)
		{
			return systems.Add(groupName, system, setEnabled);
		}

		/// <summary>
		/// Sets whether system is enabled
		/// </summary>
		public static void SystemEnabled<C>(bool setEnabled) where C: EntitySystem
		{
			systems.SetEnabled<C>(setEnabled);
		}

		/// <summary>
		/// Returns a list of Systems in group
		/// </summary>
		public static List<EntitySystem> GetSystemGroup (string name)
		{
			return systems.GetSystemGroup(name);
		}

		static void OnLoadScene()
		{
			_systems = null;
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

	public class EntitySystems : MonoBehaviour
	{
		public Dictionary<Type, EntitySystem> _systemLookup = new Dictionary<Type, EntitySystem>();		// System Lookup
		public List<EntitySystem> _updateSystems = new List<EntitySystem>();							// update systems
		public List<EntitySystem> _fixedUpdateSystems = new List<EntitySystem>();						// fixed update systems
		public Dictionary <string, SystemGroup> _systemGroups = new Dictionary<string, SystemGroup>(); 	// System Groups

		/// <summary>
		/// Add the specified system. Can string adding systems together
		/// </summary>
		public EntitySystems Add(EntitySystem system)
		{
			return Add("", system, true);
		}

		/// <summary>
		/// Add the specified system and sets if enabled.
		/// </summary>
		public EntitySystems Add(EntitySystem system, bool setEnabled)
		{
			return Add("", system, setEnabled);
		}

		/// <summary>
		/// Add the specified system to Group.
		/// </summary>
		public EntitySystems Add(string Group, EntitySystem system)
		{
			return Add(Group, system, true);
		}

		/// <summary>
		/// Add the specified system to Group and sets enabled.
		/// </summary>
		public EntitySystems Add(string groupName, EntitySystem system, bool setEnabled)
		{
			if (_systemLookup.ContainsKey(system.GetType()))	// Only allowing 1 instance of a system since a system manipulates all components. Systems will update components irrespective of managers
			{
				#if UNITY_EDITOR
				Debug.LogError(string.Format("{0} already exsits in {1}. Can only have 1 instance of system in Manager", system.GetType()));
				#endif
				return this;	// early out if already added
			}

			_systemLookup[system.GetType()] = system;	// add to lookups

			if (string.IsNullOrEmpty(groupName))		// change name to default if none
				groupName = "Default";
			
			SystemGroup systemGroup;
			if (!_systemGroups.TryGetValue(groupName, out systemGroup))	// if group not found make a new one
			{
				systemGroup = new SystemGroup();
				systemGroup.name = groupName;
				_systemGroups[groupName] = systemGroup;
			}
			systemGroup.systems.Add(system); // add system to group

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
		public void SetEnabled<C>(bool setEnabled) where C: EntitySystem
		{
			EntitySystem system;
			if (_systemLookup.TryGetValue(typeof(C), out system))
			{
				system.enabled = setEnabled;
			}
			else 
			{
				#if UNITY_EDITOR
				Debug.LogError(string.Format("{0} not found. Add {0} to Entity System Manager", typeof(C)));
				#endif
			}
		}

		public List<EntitySystem> GetSystemGroup (string name)
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


		void Awake()
		{
			SetEntityLinks();
		}

		/// <summary>
		/// Updates Systems
		/// </summary>
		void Update()
		{
			for (int i = 0; i < _updateSystems.Count; ++i)	// process all update systems
			{
				if (_updateSystems[i].enabled)
					_updateSystems[i].Update();
			}
		}

		void FixedUpdate()
		{
			for (int i = 0; i < _fixedUpdateSystems.Count; ++i)	// process all fixed update systems
			{
				if (_fixedUpdateSystems[i].enabled)
					_fixedUpdateSystems[i].FixedUpdate();
			}
		}

		void OnDestroy()
		{
			ECSManager.LoadSceneEvent();
			DisableAllSystems();
			UnSetEntityLinks();
			//Debug.Log("Systems Destroyed");
		}

		void DisableAllSystems()
		{
			foreach( EntitySystem system in _systemLookup.Values)
			{
				system.OnDisable();
			}
		}

		void SetEntityLinks()
		{
			EntityLink[] links = GameObject.FindObjectsOfType<EntityLink>();
			foreach( var link in links)
			{
				link.SetEntity(ECSManager.CreateEntity());
				link.SetUpComponents();
			}
		}

		void UnSetEntityLinks()
		{
			EntityLink[] links = GameObject.FindObjectsOfType<EntityLink>();
			foreach( var link in links)
			{
				link.SetEntity(null);
			}
		}
	}
}