using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/BulletComponent")]
public class BulletComponent : EntityComponent<BulletComponent>
{
	public float timeAlive = 0;

	void OnTriggerEnter(Collider col)
	{
		var e = col.gameObject.GetComponentInParent<Entity>();

		e.SendEvent<BulletCollisionEvent>(new BulletCollisionEvent());
	}
}