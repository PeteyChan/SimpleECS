using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/EnemyDamageSystem")]
public class EnemyDamageSystem : EntitySystem, UpdateSystem
{
	public override void InitializeSystem ()
	{
		AddEntityEvent<BulletCollisionEvent>(OnBulletCollisionEvent);
	}

	void OnBulletCollisionEvent(Entity entity, BulletCollisionEvent args)
	{
		if (entity.Has<EnemyComponent>())
		{
			var spin = entity.GetOrAdd<SpinComponent>();
			spin.timeSpinning = 0;
			spin.enabled = true;
		}
	}

}

public struct BulletCollisionEvent{}
