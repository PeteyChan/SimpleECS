using UnityEngine;
using System.Collections;
using ECS;

public class EnemyLink : EntityLink 
{
	public override void SetUpComponents ()
	{
		entity
			.Set<MoveComponent>(move)
			.Add<EnemyComponent>()
			.Set<FactionComponent>(faction)
			.Set<ShootBulletComponent>(shoot)

			;
		entity.GetSet<PositionComponent>(pos).position.x = 10f;
		entity.GetAdd<ViewComponent>().gameobject = gameObject;
		entity.Set<ResourceComponent>(res);
	}

	public MoveComponent move;
	public PositionComponent pos;
	public ResourceComponent res;
	public FactionComponent faction;
	public ShootBulletComponent shoot;
}
