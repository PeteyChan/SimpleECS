using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/EnemyMove")]
public class EnemyMove : EntitySystem<InputComponent, EnemyComponent>, IUpdate
{
	public float resetXBound = -10;

	public override void UpdateSystem (InputComponent input, EnemyComponent enemy)
	{
		input.xAxis = -4f;

		if (enemy.transform.position.x < resetXBound)
		{
			enemy.SendEvent<DespawnEvent>(enemy.entity, new DespawnEvent());
		}
	}
}
