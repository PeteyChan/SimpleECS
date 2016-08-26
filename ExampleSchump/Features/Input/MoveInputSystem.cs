using UnityEngine;
using System.Collections;
using ECS;

public class MoveInputSystem : EntitySystem, IUpdateSystem
{
	Group<MoveInputComponent, MoveComponent> gInputMove;
	public override void SetGroups ()
	{
		gInputMove = Groups.GetGroup<MoveInputComponent, MoveComponent>();
	}

	public override void Update ()
	{
		gInputMove.Process( (MoveInputComponent input, MoveComponent move) => 
			{
				move.xAxis = input.xAxis;
				move.yAxis = input.yAxis;
			});
	}

}
