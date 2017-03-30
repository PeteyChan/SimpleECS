using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/InputComponent")]
public class InputComponent : EntityComponent<InputComponent>
{
	public float xAxis;
	public float yAxis;
	public bool shoot;
}
