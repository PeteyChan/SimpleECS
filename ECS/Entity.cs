using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[DisallowMultipleComponent]
public class Entity : MonoBehaviour
{
	public int ID;
	public EntityComponent[] componentLookup;

	void Awake()
	{
		if (EntityManager.instance == null) return;
		ID = EntityManager.instance.GetID;
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

	public void InovkeEvent<E>(Entity sender, E args)
	{
		EntityManager.instance.InvokeEvent(sender, this, args);
	}

}

public delegate void EntityEvent<E>(Entity sender, Entity reciever, E args);