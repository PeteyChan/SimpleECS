using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/EnemyShoot")]
public class EnemyShoot : EntitySystem<EnemyComponent, InputComponent>, IUpdate
{
	public override void UpdateSystem (EnemyComponent enemy, InputComponent input)
	{
		if (input.shoot)
			input.shoot = false;

		if (Time.time > enemy.NextShotTime)
		{
			input.shoot = true;

			enemy.NextShotTime = Time.time + enemy.ShotReload + Random.Range(-enemy.Randomizer , enemy.Randomizer);
		}
	}
}
