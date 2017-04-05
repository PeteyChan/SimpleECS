using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/PlayerShootSystem")]
public class PlayerShootSystem : EntitySystem<PlayerComponent, InputComponent>, UpdateSystem
{
	public GameObject Bullet;

	public override void UpdateSystem (PlayerComponent player, InputComponent input)
	{
		var transform = player.entity.transform;

		if (Time.time > player.lastShotTime + player.reloadTime && input.shoot)
		{
			Instantiate(Bullet, transform.position, transform.rotation);
			player.lastShotTime = Time.time;
		}
	}
}
