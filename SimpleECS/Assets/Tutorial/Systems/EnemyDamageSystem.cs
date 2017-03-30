using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/EnemyDamageSystem")]
public class EnemyDamageSystem : EntitySystem, IUpdate
{
	public override void InitializeSystem ()
	{
		AddEvent<BulletCollisionEvent>(OnBulletCollisionEvent);
	}

	void OnBulletCollisionEvent(Entity sender, Entity reciever, BulletCollisionEvent args)
	{
		if (reciever.Has<EnemyComponent>())
		{
			var spin = reciever.GetOrAdd<SpinComponent>();
			spin.timeSpinning = 0;
			spin.enabled = true;
		}
	}

}

public struct BulletCollisionEvent{}
