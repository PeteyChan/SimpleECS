using UnityEngine;
using System.Collections;
using ECS;

[System.Serializable]
public class ShootBulletComponent : EntityComponent
{
	public bool Shoot = false;

	[Range(0.1f, 2f)]
	public float ReloadRate = .3f;
	[HideInInspector]
	public float CountdownTimer= 0f;

	public string BulletResource = Loader.Bullet;
	public Vector3 BulletDirection = Vector3.up;

	public Faction faction
	{
		get 
		{
			return entity.GetAdd<FactionComponent>().faction;
		}
	}
}
