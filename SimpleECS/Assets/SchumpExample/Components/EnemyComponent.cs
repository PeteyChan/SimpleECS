using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/EnemyComponent")]
public class EnemyComponent : EntityComponent<EnemyComponent>
{
	public float ShotReload = 5f;
	public float Randomizer = 3f;

	[HideInInspector]
	public float NextShotTime;
}
