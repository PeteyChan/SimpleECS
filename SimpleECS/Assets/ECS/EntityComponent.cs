using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;


/// <summary>
/// C needs to Match the derived component
/// </summary>
public abstract class EntityComponent<C> : EntityComponent where C : EntityComponent<C>
{
	ComponentHolder holder = new ComponentHolder(); // A copy the Component Holder on the Entity
	int _componentID;  	 	// the array index to this component in the entity component lookup
	bool _isRegistered; 	// registration flag, ensures that the component does nothing if not registered  
	void Awake()
	{
		if (!EntityManager.loaded)
		{
			return;
		}

		_componentID = Group<C>.instance.ID;
		entity = GetComponentInParent<Entity>();   		// traverse the heirarchy for Entity
		if (entity == null)
			entity = gameObject.AddComponent<Entity>();	// If none found create a new one

		if (!entity[_componentID].has)					// If entity currently doesn't have this component
		{
			holder.has = true;
			holder.component =  this;
			entity[_componentID] = holder;				// set entity component to this
			_isRegistered = true;						// set that the component has been registered with Entity
		}
		else
		{
			Debug.LogFormat("Cannot Add more than one {0} to Entity {1}: ID {2}", typeof(C), entity.name, entity.ID);
			Destroy(this);								// Else destroy this Component
		} 
	}

	void OnEnable()
	{
		if (_isRegistered)								// Only Run code if this component has been registered to Entity
		{
			holder.enabled = true;
			entity[_componentID] = holder;			// Holder needs to be reassigned since it's a struct
			Group<C>.instance.EnableComponent((C)this);	// This Callback Keeps the Systems Up-To-Date
		}
	}

	void OnDisable()
	{
		if (_isRegistered)
		{
			Group<C>.instance.DisableComponent((C)this);    // Event needs to be called before removing instance from entity
			holder.enabled = false;
			entity[_componentID] = holder;
		}
	}

	void OnDestroy()
	{
		if (_isRegistered)
		{
			holder.has = false;
			holder.component = null;
			entity[_componentID] = holder;
		}
	}
}
	
public abstract class EntityComponent : MonoBehaviour
{
	[ReadOnly]
	public Entity entity;

	/// <summary>
	/// Calls Events on Entity that Match Argument's Type.
	/// </summary>
	public void SendEvent<E>(E args)
	{
		entity.SendEvent(args);
	}

	/// <summary>
	/// Returns true if entity contains component
	/// </summary>
	public bool Has<C>() where C : EntityComponent<C>
	{
		return entity[Group<C>.instance.ID].has;
	}

	/// <summary>
	/// Returns true if entity contains component and is enabled
	/// </summary>
	public bool HasEnabled<C>() where C : EntityComponent<C>
	{
		return entity[Group<C>.instance.ID].enabled;
	}

	/// <summary>
	/// Returns true if has component. Outputs component
	/// </summary>
	public bool TryGet<C>(out C component) where C: EntityComponent<C>
	{
		ComponentHolder h = entity[Group<C>.instance.ID];
		component = (C)h.component;
		return h.has;
	}

	/// <summary>
	/// Returns true if has component and enabled. Outputs component;
	/// </summary>
	public bool TryGetEnabled<C>(out C component) where C : EntityComponent<C>	// used to speed up systems a little bit
	{
		ComponentHolder h = entity[Group<C>.instance.ID];
		component = (C)h.component;
		return h.enabled;
	}

	/// <summary>
	/// Returns Component if in variable, returns false 
	/// </summary>
	public C Get<C>() where C : EntityComponent<C>
	{
		return (C)entity[Group<C>.instance.ID].component;
	}

	/// <summary>
	/// Returns Component or Adds and returns Component if None Found.
	/// </summary>
	public C GetOrAdd<C>() where C : EntityComponent<C>
	{
		var c = Get<C>();
		if (c == null) 
			c = gameObject.AddComponent<C>();
		return c;
	}

	/// <summary>
	/// Removes Component
	/// </summary>
	public void Remove<C>() where C : EntityComponent<C>
	{
		var c = Get<C>();
		if (c != null)
			Destroy(c);
	}
}
