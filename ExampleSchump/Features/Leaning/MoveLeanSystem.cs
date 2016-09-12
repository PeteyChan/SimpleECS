using UnityEngine;
using System.Collections;
using ECS;

public class EulerBankSystem : EntitySystem, IUpdate 
{
	Group<MoveComponent, EulerAnglesComponent> gMoveEuler;

	public override void SetGroups ()
	{
		gMoveEuler = Groups.GetGroup<MoveComponent, EulerAnglesComponent>();
	}

	public override void Update ()
	{
		gMoveEuler.Process( (MoveComponent move, EulerAnglesComponent euler) => 
			{
				euler.Angle.y = 50f* move.xAxis;
				euler.Angle.x = 10f* move.yAxis;
			});
	}
}
