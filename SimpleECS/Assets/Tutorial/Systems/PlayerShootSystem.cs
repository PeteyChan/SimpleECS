using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/PlayerShootSystem")]
public class PlayerShootSystem : EntitySystem
{
	public GameObject Bullet;


	public override void Initialize ()
	{
		AddUpdate<PlayerComponent, InputComponent>(UpdateSystem);
	}

	public void UpdateSystem (PlayerComponent player, InputComponent input)
	{
		var transform = player.entity.transform;

		if (Time.time > player.lastShotTime + player.reloadTime && input.shoot)
		{
			Instantiate(Bullet, transform.position, transform.rotation);
			player.lastShotTime = Time.time;
		}
	}
}
