using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/PlayerMove")]
public class PlayerMove : EntitySystem<PlayerComponent, InputComponent>, IUpdate
{
	public float moveSpeed;

	public string XAxisInput = "Horizontal";
	public string YAxisInput = "Vertical";
	public string Shoot = "Fire1";

	public override void UpdateSystem (PlayerComponent player, InputComponent input)
	{
		input.xAxis = Input.GetAxis(XAxisInput)*moveSpeed;
		input.yAxis = Input.GetAxis(YAxisInput)*moveSpeed;
		input.shoot = Input.GetButton(Shoot);
	}
}
