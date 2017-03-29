using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

public abstract class EntityComponent<C> : EntityComponent where C : EntityComponent<C>
{
	bool _reg;
	void Awake()
	{
		entity = GetComponentInParent<Entity>();
		if (entity == null)
			entity = gameObject.AddComponent<Entity>();

		if (entity[Group<C>.instance.ID] == null)
		{
			entity[Group<C>.instance.ID] = this;
			_reg = true;
		}
		else
		{
			Debug.LogFormat("Cannont Add more than one {0} to Entity {1}: ID {2}", typeof(C), entity.name, entity.ID);
			Destroy(this);	
		} 
	}

	void OnEnable()
	{
		if (_reg)
			Group<C>.instance.AddComponent((C)this);
	}

	void OnDisable()
	{
		if (_reg)
		{
			Group<C>.instance.RemoveComponent((C)this);	
		}
	}

	void OnDestroy()
	{
		if (_reg)
			entity[Group<C>.instance.ID] = null;
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
