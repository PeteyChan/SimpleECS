using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/MoveBullet")]
public class MoveBullet : EntitySystem<BulletComponent, RigidbodyComponent>, IFixedUpdate
{
	public float BulletSpeed = 20f;


	public override void FixedUpdateSystem (BulletComponent bullet, RigidbodyComponent rigidbody)
	{
		rigidbody.velocity = bullet.transform.up*BulletSpeed;
		bullet.currentLifeTime += Time.fixedDeltaTime;

		if (bullet.currentLifeTime > bullet.LifeTime)
		{
			bullet.currentLifeTime = 0;
			GameObjectPool.Pool(bullet.entity.gameObject);
		}
	}
}
