using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/MoveRigidbodyViaInputSystem")]
public class MoveRigidbodyViaInputSystem : EntitySystem
{
	public override void Initialize ()
	{
		AddFixedUpdate<InputComponent, RigidbodyComponent>(FixedUpdateSystem);
	}

	public void FixedUpdateSystem (InputComponent input, RigidbodyComponent rigidbody)
	{
		rigidbody.velocity = new Vector3(input.xAxis , input.yAxis, 0);
	}
}
