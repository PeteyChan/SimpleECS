using UnityEngine;
using System.Collections;
using ECS;

public class MoveEnemyLeftSystem : EntitySystem , IUpdate
{
	Group<EnemyComponent, MoveComponent, PositionComponent> gEnemyMove;

	public override void SetGroups ()
	{
		gEnemyMove = Groups.GetGroup<EnemyComponent, MoveComponent, PositionComponent>();
	}

	public override void Update ()
	{
		gEnemyMove.Process( (EnemyComponent enemy, MoveComponent move, PositionComponent pos) =>
			{
				move.xAxis = -1f;

				if (pos.position.x < -10)
					pos.position.x = 10f;
				pos.position.y = 3f;
			});
	}


}
