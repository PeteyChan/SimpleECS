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

		// current components
		//public int[] _components;

		/// <summary>
		/// Adds the component.
		/// </summary>
		public Entity Add<C>() where C: EntityComponent
		{
//			if(Has(ComponentPool<C>.ID))
//			{
//				#if UNITY_EDITOR
//				//Debug.Log(string.Format("Enitity {0} already has {1} attached", ID, typeof(C).ToString()));
//				#endif
//				return this;
//			}
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
			return EntityManager.EntityLookup[ID][ComponentPool<C>.ID] > 0;
		}

		public bool Has(int componentID)
		{
			return EntityManager.EntityLookup[ID][componentID] > 0;
		}

		/// <summary>
		/// Sets the component to value
		/// If no component found adds it to entity
		/// </summary>
		public Entity Set<C>(C value) where C:EntityComponent
		{
			if (!Has<C>())
				Add<C>();
			ComponentPool<C>.components[EntityManager.EntityLookup[ID][ComponentPool<C>.ID]] = value;
			value.entity = this;
			return this;
		}

		/// <summary>
		/// Sets the component to value
		/// If no component found adds it to entity
		/// Returns Component
		/// </summary>
		public C GetSet<C>(C value) where C : EntityComponent
		{
			if (!Has<C>())
				Add<C>();
			ComponentPool<C>.components[EntityManager.EntityLookup[ID][ComponentPool<C>.ID]] = value;
			value.entity = this;
			return value;
		}

		/// <summary>
		/// Gets the component. Returns null if none.
		/// </summary>
		public C Get<C>() where C: EntityComponent, new()
		{
			return ComponentPool<C>.GetComponent(this);
		}
			
		/// <summary>
		/// Tries to get component if one available
		/// </summary>
		public bool TryGet<C>(out C Component) where C: EntityComponent, new()
		{
			Component = Get<C>();
			if(Component == null)
				return false;
			return true;
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
			EntityManager.DestroyEntity(this);
		}
			
		public static Entity GetEntity(int ID)
		{
			return EntityManager.GetEntity(ID);
		}

		public static Entity CreateEntity()
		{
			return EntityManager.CreateEntity();
		}

		public static int TotalEntitiesCount()
		{
			return EntityManager.TotalEntitiesCount();
		}

		public static int PooledEntitiesCount()
		{
			return EntityManager.PooledEntitiesCount();
		}

		public static int ActiveEntitiesCount()
		{
			return EntityManager.ActiveEntitiesCount();
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

		/// <summary>
		/// Gets called before Removed from Entity
		/// </summary>
		public virtual void OnRemove()
		{}
	}
}
