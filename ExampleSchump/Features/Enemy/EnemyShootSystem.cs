using UnityEngine;
using System.Collections;
using ECS;

public class EnemyShootSystem : EntitySystem , IUpdateSystem
{
	Group<EnemyComponent, ShootBulletComponent> gEnemyShoot;

	public override void SetGroups ()
	{
		gEnemyShoot = Groups.GetGroup<EnemyComponent, ShootBulletComponent>();
	}

	public override void Update ()
	{
		gEnemyShoot.Process( (EnemyComponent enemy, ShootBulletComponent shoot) => 
			{
				if (shoot.CountdownTimer <= 0)
				{
					float randomValue = Random.Range(0f, 1f);
					if (randomValue < 0.5f)
						shoot.Shoot = true;
					else shoot.CountdownTimer += randomValue;
				}
			});
	}

}
