using UnityEngine;
using System.Collections.Generic;
using ECS.Internal;
using System;

namespace ECS
{
	public abstract class Groups	// To allow dictionary use
	{
		// reference to all groups
		static Dictionary<Type, Groups> _groups
		{
			get {return EntityPool._groups;}
		}

		/// <summary>
		/// Fires Event when Component is Added.
		/// Returns associated Entity.
		/// </summary>
		public static void AddComponentEvent<C>(ComponentEvent listener, bool subscribe) where C : EntityComponent, new()
		{
			if(subscribe)
				ComponentPool<C>.AddComponentEvent += listener;
			else
				ComponentPool<C>.AddComponentEvent -= listener;
		}

		/// <summary>
		/// Fires Event when Component is Removed.
		/// Returns associated Entity.
		/// </summary>
		public static void RemoveComponentEvent<C>(ComponentEvent listener, bool subscribe) where C: EntityComponent, new()
		{
			if (subscribe)
				ComponentPool<C>.RemoveComponentEvent += listener;
			else
				ComponentPool<C>.RemoveComponentEvent -= listener;
		}

		/// <summary>
		/// Gets Group that allows processing of all entities that have the component.
		/// </summary>
		public static Group<C> GetGroup<C>() where C: EntityComponent, new()
		{
			Groups lookUpGroup;
			if (_groups.TryGetValue(typeof(Group<C>), out lookUpGroup))
			{
				return lookUpGroup as Group<C>;
			}
			Group<C> newGroup = new Group<C>();
			_groups.Add(typeof(Group<C>), newGroup);
			return newGroup;
		}

		/// <summary>
		/// Gets Group that allows processing of all entities that have all components.
		/// </summary>
		public static Group<C1, C2> GetGroup<C1, C2>()
			where C1: EntityComponent, new()
			where C2: EntityComponent, new()
		{
			Groups lookUpGroup;
			if (_groups.TryGetValue(typeof(Group<C1, C2>), out lookUpGroup))
			{
				return lookUpGroup as Group<C1, C2>;
			}
			Group<C1, C2> newGroup = new Group<C1, C2>();
			_groups.Add(newGroup.GetType(), newGroup);
			return newGroup;
		}


		/// <summary>
		/// Gets Group that allows processing of all entities that have all components.
		/// </summary>
		public static Group<C1, C2, C3> GetGroup<C1, C2, C3>()
			where C1: EntityComponent, new()
			where C2: EntityComponent, new()
			where C3: EntityComponent, new()
		{
			Groups lookUpGroup;
			if (_groups.TryGetValue(typeof(Group<C1, C2, C3>), out lookUpGroup))
			{
				return lookUpGroup as Group<C1, C2, C3>;
			}
			Group<C1, C2, C3> newGroup = new Group<C1, C2, C3>();
			_groups.Add(newGroup.GetType(), newGroup);
			return newGroup;
		}

		/// <summary>
		/// Gets Group that allows processing of all entities that have all components.
		/// </summary>
		public static Group<C1, C2, C3, C4> GetGroup<C1, C2, C3, C4>()
			where C1: EntityComponent, new()
			where C2: EntityComponent, new()
			where C3: EntityComponent, new()
			where C4: EntityComponent, new()
		{
			Groups lookUpGroup;
			if (_groups.TryGetValue(typeof(Group<C1, C2, C3, C4>), out lookUpGroup))
			{
				return lookUpGroup as Group<C1, C2, C3, C4>;
			}
			Group<C1, C2, C3, C4> newGroup = new Group<C1, C2, C3, C4>();
			_groups.Add(newGroup.GetType(), newGroup);
			return newGroup;
		}

		/// <summary>
		/// Returns the component ID of Component
		/// </summary>
		public static int GetComponentID<C>() where C : EntityComponent, new()
		{
			return EntityPool.GetComponentID<C>();
		}
	}

}
