using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/SpinComponent")]
public class SpinComponent : EntityComponent<SpinComponent>
{
	public float spinSpeed = 5f;
	[HideInInspector]
	public float timeSpinning = 0;
	public float maxSpinTime = 1f;
}
