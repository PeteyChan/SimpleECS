using UnityEngine;
using System.Collections;
using ECS;

public class ShootBulletSystem : EntitySystem , IUpdate
{
	Group<ShootBulletComponent> gShootBullet;

	public override void SetGroups ()
	{
		gShootBullet = Groups.GetGroup<ShootBulletComponent>();
	}

	public override void Update ()
	{
		gShootBullet.Process( (ShootBulletComponent shooter) =>
			{
				if ( shooter.CountdownTimer > 0)
					shooter.CountdownTimer -= Time.deltaTime;
				else
				{
					if (shooter.Shoot)
					{
						shooter.CountdownTimer = shooter.ReloadRate;
						shooter.Shoot = false;
						SpawnBullet(shooter);	
					}
				}
			});
	}

	void SpawnBullet(ShootBulletComponent shoot)
	{
		Entity e = Entity.Create();
		e.GetAdd<FactionComponent>().faction = shoot.faction;
		e.GetAdd<ResourceComponent>().path = shoot.BulletResource;
		e.Add<ViewComponent>();
		e.GetAdd<MoveComponent>().yAxis = shoot.BulletDirection.y;
		e.GetAdd<PositionComponent>().position = shoot.entity.Get<PositionComponent>().position;
	}
}
