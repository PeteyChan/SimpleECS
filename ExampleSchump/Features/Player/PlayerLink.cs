using UnityEngine;
using System.Collections;
using ECS;

public class PlayerLink : EntityLink 
{
	public override void SetUpComponents ()
	{
		ViewComponent view = new ViewComponent();
		view.gameobject = gameObject;

		entity
			.Set<MoveComponent>(move)
			.Set<PositionComponent>(pos)
			.Add<PlayerComponent>()
			.Add<MoveInputComponent>()
			.Set<ShootBulletComponent>(shoot)
			.Add<ShootInputComponent>()
			.Add<EulerAnglesComponent>()
			.Set<FactionComponent>(faction)

			;
		
		entity.Set<ViewComponent>(view);
		entity.Set<ResourceComponent>(res);

	}

	public MoveComponent move;
	public PositionComponent pos;
	public ResourceComponent res;
	public ShootBulletComponent shoot;
	public FactionComponent faction;


}


