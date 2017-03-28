using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/BulletComponent")]
public class BulletComponent : EntityComponent<BulletComponent>
{
	void OnTriggerEnter(Collider collider)
	{
		var entityComponent = collider.GetComponentInParent<EntityComponent>();

		var faction = entity.Get<FactionComponent>().faction;

		if (faction == Faction.Enemy)
			entityComponent.SendEvent(entity, new EnemyAttackEvent(this));
		if (faction == Faction.Player)
			entityComponent.SendEvent(entity, new PlayerAttackEvent(this));
	}

	[Range(.5f, 2f)]
	public float LifeTime = 1f;

	[HideInInspector]
	public float currentLifeTime = 0;
}
