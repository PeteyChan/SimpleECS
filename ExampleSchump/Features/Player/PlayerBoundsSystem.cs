using UnityEngine;
using System.Collections;
using ECS;

public class PlayerBoundsSystem : EntitySystem , IUpdate
{
	Group<PlayerComponent, PositionComponent> gPlayerPos;

	public override void SetGroups ()
	{
		gPlayerPos = Groups.GetGroup<PlayerComponent, PositionComponent>();
	}


	public override void Update ()
	{
		gPlayerPos.Process( (PlayerComponent c1, PositionComponent pos) => 
			{
				if (pos.position.x < -7.5f)
					pos.position.x = -7.5f;
				if (pos.position.x > 7.5f)
					pos.position.x = 7.5f;
				if (pos.position.y > 1f)
					pos.position.y = 1f;
				if (pos.position.y < -3.5f)
					pos.position.y = -3.5f;
			});
	}



}
