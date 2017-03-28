using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/ShakeComponent")]
public class ShakeComponent : EntityComponent<ShakeComponent>
{
	public float maxShakeTime = .5f;
	public float shakeAmount = 20f;
	public float shakeSpeed = 5f;

	[ReadOnly]
	public float currentShakeTime = 0f;
}
