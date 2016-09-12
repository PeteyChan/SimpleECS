using UnityEngine;
using System.Collections;
using ECS;

public class MoveSystem : EntitySystem , IUpdate
{
	Group<MoveComponent, PositionComponent> gMovePos;

	public override void SetGroups ()
	{
		gMovePos = Groups.GetGroup<MoveComponent, PositionComponent>();
	}

	public override void Update ()
	{
		gMovePos.Process( (MoveComponent move, PositionComponent pos) => 
			{
				pos.position.x += move.xAxis* move.speed* Time.deltaTime;
				pos.position.y += move.yAxis* move.speed* Time.deltaTime;
			});
	}


}
