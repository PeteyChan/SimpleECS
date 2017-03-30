using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleECS.Internal;

public abstract class EntityComponent<C> : EntityComponent where C : EntityComponent<C>
{
	ComponentHolder holder = new ComponentHolder();

	int _id;
	bool _reg;
	void Awake()
	{
		_id = Group<C>.instance.ID;
		entity = GetComponentInParent<Entity>();
		if (entity == null)
			entity = gameObject.AddComponent<Entity>();

		if (entity[_id].component == null)
		{
			holder.component = this;
			holder.has = true;
			entity[_id] = holder;
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
		{
			holder.enabled = true;
			entity[_id] = holder;
			Group<C>.instance.AddComponent((C)this);
		}
	}

	void OnDisable()
	{
		if (_reg)
		{
			holder.enabled = false;
			entity[_id] = holder;
			Group<C>.instance.RemoveComponent((C)this);
		}
	}

	void OnDestroy()
	{
		if (_reg)
		{
			holder.component = null;
			holder.has = false;
			entity[_id] = holder;
		}
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
