using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/MoveRigidbodyViaInputSystem")]
public class MoveRigidbodyViaInputSystem : EntitySystem<InputComponent, RigidbodyComponent>, FixedUpdateSystem
{
	public override void FixedUpdateSystem (InputComponent input, RigidbodyComponent rigidbody)
	{
		rigidbody.velocity = new Vector3(input.xAxis , input.yAxis, 0);
	}
}
