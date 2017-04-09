using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/MoveBulletSystem")]
public class MoveBulletSystem : EntitySystem
{
	public float bulletSpeed = 20f; 
	public float bulletLife = 1f;

	public override void Initialize ()
	{
		AddUpdate<BulletComponent, RigidbodyComponent>(UpdateSystem);
	}

	public void UpdateSystem (BulletComponent bullet, RigidbodyComponent rigidbody)
	{
		bullet.timeAlive += Time.fixedDeltaTime;

		rigidbody.velocity = bullet.transform.up * bulletSpeed;
	
		if (bullet.timeAlive > bulletLife)
		{
			bullet.entity.Destroy();
		}
	}
}
