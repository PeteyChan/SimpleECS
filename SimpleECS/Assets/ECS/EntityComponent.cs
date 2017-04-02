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
		if (EntityManager.instance == null)
		{
			Destroy(this);
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
			entity[_componentID] = holder;				// Holder needs to be reassigned since it's a struct
			Group<C>.instance.EnableComponent((C)this);	// This Callback Keeps the Systems Up-To-Date
		}
	}

	void OnDisable()
	{
		if (_isRegistered)
		{
			holder.enabled = false;
			entity[_componentID] = holder;
			Group<C>.instance.DisableComponent((C)this);
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

	// will make collection lookups faster for collections of the same component however
	// will make lookups slower if collection contains different types of components
	public override int GetHashCode ()
	{
		return entity.ID;
	}

	public override bool Equals (object other)
	{
		if (other is C)
			return ((C)other).entity.ID == entity.ID;;
		return false;
	}
}
	
public abstract class EntityComponent : MonoBehaviour
{
	[ReadOnly]
	public Entity entity;

	public void SendEvent<E>(Entity sender, E args)
	{
		entity.SendEvent(sender, args);
	}
}
