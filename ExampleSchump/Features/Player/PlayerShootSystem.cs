using UnityEngine;
using System.Collections;
using ECS;

public class PlayerShootSystem : EntitySystem, IUpdate
{
	Group<ShootInputComponent, ShootBulletComponent> gInputBullet;

	public override void SetGroups ()
	{
		gInputBullet = Groups.GetGroup<ShootInputComponent, ShootBulletComponent>();
	}

	public override void Update ()
	{
		gInputBullet.Process( (ShootInputComponent input, ShootBulletComponent bullet) =>
			{
				bullet.Shoot = input.shoot;
			});
	}



}
