using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/ShootGuns")]
public class ShootGuns : EntitySystem <GunHolderComponent, InputComponent>, IUpdate
{
	public override void InitializeSystem ()
	{
		AddEvent<ShootEvent>(OnShootGun);
	}

	public override void UpdateSystem (GunHolderComponent gunHolder, InputComponent input)
	{
		if (input.shoot)
		{
			foreach(var gun in gunHolder.Guns)
			{
				gun.SendEvent(gunHolder.entity, new ShootEvent(gun));
			}
		}
	}

	void OnShootGun(Entity sender, Entity reciever, ShootEvent args)
	{
		var gun = args.gun;

		if (gun.LastShotTime + gun.ReloadTime < Time.time)
		{
			gun.LastShotTime = Time.time;

			var bullet = GameObjectPool.Get(args.gun.Bullet.gameObject);

			bullet.transform.position = gun.transform.position;
			bullet.transform.rotation = gun.transform.rotation;
		}
	}
}

public class ShootEvent
{
	public ShootEvent(GunComponent gun)
	{
		this.gun = gun;
	}

	public GunComponent gun;
}
