using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[DisallowMultipleComponent]
public class Entity : MonoBehaviour
{
	[ReadOnly, SerializeField]
	int id;
	public int ID
	{
		get {return id;}
	}

	EntityComponent[] componentLookup;

	void Awake()
	{
		if (EntityManager.instance == null) return;
		id = EntityManager.instance.GetID;
		componentLookup = new EntityComponent[EntityManager.instance.GetComponentCount()];
	}

	public EntityComponent this[int key]
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

	public bool Has<C>() where C : EntityComponent<C>
	{
		return componentLookup[Group<C>.instance.ID] != null;
	}

	public bool HasEnabled<C>() where C : EntityComponent<C>
	{
		var c = componentLookup[Group<C>.instance.ID];
		if (c == null)
			return false;
		return c.enabled;
	}

	public C Get<C>() where C : EntityComponent<C>
	{
		return (C)componentLookup[Group<C>.instance.ID];
	}

	public C GetOrAdd<C>() where C : EntityComponent<C>
	{
		var c = Get<C>();
		if (c == null) 
			c = gameObject.AddComponent<C>();
		return c;
	}

	public void Remove<C>() where C : EntityComponent<C>
	{
		var c = Get<C>();
		if (c != null)
			Destroy(c);
	}

	public override bool Equals (object other)
	{
		if (other is Entity)
			return ((Entity)other).ID == ID;
		return false;
	}

	public override int GetHashCode ()
	{
		return ID;
	}

	public void SendEvent<E>(Entity sender, E args)
	{
		EntityManager.instance.InvokeEvent(sender, this, args);
	}

}

public delegate void EntityEvent<E>(Entity sender, Entity reciever, E args);