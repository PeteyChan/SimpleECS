using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SimpleECS.Internal;

[DisallowMultipleComponent]
public class Entity : MonoBehaviour
{
	[ReadOnly, SerializeField]
	int id;
	public int ID
	{
		get {return id;}
	}
		
	ComponentHolder[] componentLookup;

	void Awake()
	{
		if (EntityManager.instance == null) return;
		EntityManager.instance.totalEntityCount ++;
		id = EntityManager.instance.GetID;
		componentLookup = new ComponentHolder[EntityManager.instance.GetComponentCount()];
	}

	void OnDestroy()
	{
		EntityManager.instance.totalEntityCount --;
	}

	public ComponentHolder this[int key]
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
		return componentLookup[Group<C>.instance.ID].has;
	}

	public bool HasEnabled<C>() where C : EntityComponent<C>
	{
		return componentLookup[Group<C>.instance.ID].enabled;
	}

	public C Get<C>() where C : EntityComponent<C>
	{
		return (C)componentLookup[Group<C>.instance.ID].component;
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
		return ID;
	}

	public void SendEvent<E>(Entity sender, E args)
	{
		EntityManager.instance.InvokeEvent(sender, this, args);
	}
}

namespace SimpleECS.Internal
{
	public struct ComponentHolder
	{
		public bool has;
		public bool enabled;
		public EntityComponent component;
	}
}
