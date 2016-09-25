using UnityEngine;
using System.Collections.Generic;
using System;
using ECS.Internal;

namespace ECS
{
	[System.Serializable]
	public class Entity
	{
		public readonly int ID;
		/// <summary>
		/// Unique Entity ID
		/// </summary>
		public Entity(int id)
		{
			ID = id;
		}

		/// <summary>
		/// Adds the component.
		/// </summary>
		public Entity Add<C>() where C: EntityComponent
		{
			ComponentPool<C>.GetOrAddComponent(this);
			return this;
		}

		/// <summary>
		/// Gets Component or Adds a new one if not found
		/// </summary>
		public C GetAdd<C>() where C: EntityComponent
		{
			return ComponentPool<C>.GetOrAddComponent(this);
		}

		/// <summary>
		/// Returns true if has component
		/// </summary>
		public bool Has<C>() where C: EntityComponent
		{
			return ECSManager.EntityComponentIndexLookup[ID][ComponentPool<C>.ID] > 0;
		}

		/// <summary>
		/// Returns true if entity has component with ID
		/// Alot faster than generic version
		/// </summary>
		public bool Has(int componentID)
		{
			return ECSManager.EntityComponentIndexLookup[ID][componentID] > 0;
		}

		/// <summary>
		/// Sets the component to value
		/// If no component found adds it to entity
		/// </summary>
		public Entity Set<C>(C value) where C:EntityComponent
		{
			if (value == null)
			{
				#if UNITY_EDITOR
				Debug.LogError(string.Format("Attempted to assign {0} with a value of null on enitity {1}. Ensure Component exists", typeof(C), ID));
				#endif
				return this;
			}
			ComponentPool<C>.SetComponent(this, value);
			return this;
		}

		/// <summary>
		/// Sets the component to value
		/// If no component found adds it to entity
		/// Returns Component
		/// </summary>
		public C GetSet<C>(C value) where C : EntityComponent
		{
			if (value == null)
			{
				#if UNITY_EDITOR
				Debug.LogError(string.Format("Attempted to assign {0} with a value of null on enitity {1}. Ensure Component exists", typeof(C), ID));
				#endif
				return null;
			}
			ComponentPool<C>.SetComponent(this, value);
			return value;
		}

		/// <summary>
		/// Gets the component. Returns null if none.
		/// </summary>
		public C Get<C>() where C: EntityComponent, new()
		{
			return ComponentPool<C>.components[ECSManager.EntityComponentIndexLookup[ID][ComponentPool<C>.ID]];
		}
			
		/// <summary>
		/// Tries to get component if one available
		/// </summary>
		public bool TryGet<C>(out C Component) where C: EntityComponent, new()
		{
			Component = Get<C>();
			return Component == null ? false : true;
		}

		/// <summary>
		/// Removes component from entity.
		/// </summary>
		public Entity Remove<C>() where C: EntityComponent ,new()
		{
			ComponentPool<C>.RemoveComponent(this);
			return this;
		}

		public void Destroy()
		{
			ECSManager.DestroyEntity(this);
		}
			
		public static Entity GetEntity(int ID) // can't really think of a use for this
		{
			return ECSManager.GetEntity(ID);
		}

		/// <summary>
		/// Creates a new Entity.
		/// </summary>
		public static Entity Create()
		{
			return ECSManager.CreateEntity();
		}

		public static int TotalEntitiesCount()
		{
			return ECSManager.TotalEntitiesCount();
		}

		public static int PooledEntitiesCount()
		{
			return ECSManager.PooledEntitiesCount();
		}

		public static int ActiveEntitiesCount()
		{
			return ECSManager.ActiveEntitiesCount();
		}

		public override int GetHashCode ()
		{
			return ID;
		}

	}

//	public interface EntityComponent
//	{
//		int EntityID	{get; set;}	// ID of Entity in lookup
//	}

	public abstract class EntityComponent
	{
		/// <summary>
		/// Reference to owning entity
		/// </summary>
		[HideInInspector]
		public Entity entity;
	}
}
