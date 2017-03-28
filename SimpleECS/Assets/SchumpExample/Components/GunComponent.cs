using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/GunComponent")]
public class GunComponent : EntityComponent<GunComponent>
{
	public Entity Bullet;

	public float ReloadTime;

	[HideInInspector]
	public float LastShotTime;
}
