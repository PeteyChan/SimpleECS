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
		int[] _components;

		/// <summary>
		/// Adds the component. Can string adding components for ease.
		/// </summary>
		public Entity Add<C>() where C: EntityComponent, new()
		{
			if(Has(ComponentPool<C>.ID))
			{
				#if UNITY_EDITOR
				//Debug.Log(string.Format("Enitity {0} already has {1} attached", ID, typeof(C).ToString()));
				#endif
				return this;
			}
			ComponentPool<C>.GetOrAddComponent(this);
			return this;
		}

		/// <summary>
		/// Gets the component or adds one and returns if if none.
		/// </summary>
		public C GetOrAdd<C>() where C: EntityComponent, new()
		{
			return ComponentPool<C>.GetOrAddComponent(this);
		}

		/// <summary>
		/// Check for component
		/// </summary>
		public bool Has<C>() where C: EntityComponent, new()
		{
			return Has(ComponentPool<C>.ID); 
		}

		/// <summary>
		/// Checks if Entity has all components with ID
		/// </summary>
		public bool Has(params int[] ComponentIDs)
		{
			for (int i = 0; i < ComponentIDs.Length; ++i)
			{
				if (_components[ComponentIDs[i]] < 0)
				{
					return false;
				}
			}
			return true;
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
			C component = Get<C>();
			Component = component;
			if(component == null)
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
			EntityPool.DestroyEntity(this);
		}


		/// <summary>
		/// Internal Component DO NOT use
		/// </summary>
		public void _SetComponentIndex(int ComponentID, int Value)
		{
			_components[ComponentID] = Value;
		}

		/// <summary>
		/// Internal Component DO NOT use
		/// </summary>
		public int _GetComponentIndex(int ComponentID)
		{
			return _components[ComponentID];
		}

		/// <summary>
		/// Internal Component DO NOT use
		/// </summary>
		public void _SetComponentIndexSize(int size)
		{
			_components = new int[size];
			for (int i = 0; i < size; ++i)
			{
				_components[i] = -1;
			}
		}

		public static Entity GetEntity(int ID)
		{
			return EntityPool.GetEntity(ID);
		}

		public static Entity CreateEntity()
		{
			return EntityPool.CreateEntity();
		}

		public static int TotalEntitiesCount()
		{
			return EntityPool.TotalEntitiesCount();
		}

		public static int PooledEntitiesCount()
		{
			return EntityPool.PooledEntitiesCount();
		}

		public static int ActiveEntitiesCount()
		{
			return EntityPool.ActiveEntitiesCount();
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
		public Entity Entity;

		/// <summary>
		/// Used to Initialize Entity ComponentValues
		/// </summary>
		public virtual void OnAdd()
		{}

		public virtual void OnRemove()
		{}
	}
}
