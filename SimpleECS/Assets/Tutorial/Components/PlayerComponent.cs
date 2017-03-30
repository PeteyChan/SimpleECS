using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/PlayerComponent")]
public class PlayerComponent : EntityComponent<PlayerComponent>
{
	public float reloadTime = .5f;
	[HideInInspector]
	public float lastShotTime;
}
