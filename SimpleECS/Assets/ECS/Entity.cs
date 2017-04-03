using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SimpleECS.Internal;

[DisallowMultipleComponent]
public sealed class Entity : MonoBehaviour
{
	/// <summary>
	/// Unique Entity identifier, used when adding and removing Entities from Systems
	/// </summary>
	[ReadOnly, SerializeField]
	int id;
	public int ID
	{
		get {return id;}
	}

	ComponentHolder[] componentLookup;	// As far as I'm aware Arrays use more memory than Dictionary but are ALOT faster
										// this makes my Get<Component> calls faster than the Unity Implementation
										// Index to specific Components are found in the Group<C>.instance.ID
	// Entity Setup						// The reason for getting the ID's via Singleton is that it's very fast.
	void Awake()
	{
		if (!EntityManager.loaded)	// Ensure no code is run if no EntityManager
		{
			Debug.Log("Must Add Entity Manager to Use Entities");
			return;
		}
		EntityManager.instance.totalEntityCount ++;
		id = EntityManager.instance.GetEntityID;
		componentLookup = new ComponentHolder[EntityManager.instance.GetComponentCount()];
	}

	void OnDestroy()
	{
		if (EntityManager.loaded)
			EntityManager.instance.totalEntityCount --;
	}
		
	public ComponentHolder this[int key]	// Access Components based on their ComponentID
	{
		get
		{
			return componentLookup[key];
		}
		set
		{
			componentLookup[key] = value;
		}
	}
		
	/// <summary>
	/// Returns true if entity contains component
	/// </summary>
	public bool Has<C>() where C : EntityComponent<C>
	{
		return componentLookup[Group<C>.instance.ID].has;
	}

	/// <summary>
	/// Returns true if entity contains component and is enabled
	/// </summary>
	public bool HasEnabled<C>() where C : EntityComponent<C>
	{
		return componentLookup[Group<C>.instance.ID].enabled;
	}

	/// <summary>
	/// Returns true if has component. Outputs component
	/// </summary>
	public bool TryGet<C>(out C component) where C: EntityComponent<C>
	{
		ComponentHolder h = componentLookup[Group<C>.instance.ID];
		component = (C)h.component;
		return h.has;
	}

	/// <summary>
	/// Returns true if has component and enabled. Outputs component;
	/// </summary>
	public bool TryGetEnabled<C>(out C component) where C : EntityComponent<C>	// used to speed up systems a little bit
	{
		ComponentHolder h = componentLookup[Group<C>.instance.ID];
		component = (C)h.component;
		return h.enabled;
	}

	/// <summary>
	/// Returns Component if in variable, returns false 
	/// </summary>
	public C Get<C>() where C : EntityComponent<C>
	{
		return (C)componentLookup[Group<C>.instance.ID].component;
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

	/// <summary>
	/// Destroys this entity gameobject
	/// </summary>
	public void Destroy()
	{
		Destroy(gameObject);
	}

	public override bool Equals (object other)
	{
		if (other is Entity)
			return ((Entity)other).ID == ID;
		return false;
	}
		
	public override int GetHashCode ()
	{
		return ID; // since ID's are unique this is a no brainer
	}

	/// <summary>
	/// Calls Events on Entity that Match Argument's Type.
	/// </summary>
	public void SendEvent<E>(Entity sender, E args)
	{
		EntityManager.instance.InvokeEvent(sender, this, args);
	}
}

namespace SimpleECS.Internal
{
	/// <summary>
	/// Small Stuct to make Component lookups fast
	/// </summary>
	[System.Serializable]
	public struct ComponentHolder
	{
		public ComponentHolder(bool has, bool enabled, EntityComponent component)
		{
			this.has = has; this.enabled = enabled; this.component = component;
		}

		public bool has;
		public bool enabled;
		public EntityComponent component;
	}
}
