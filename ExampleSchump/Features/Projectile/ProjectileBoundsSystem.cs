using UnityEngine;
using System.Collections;
using ECS;

public class ProjectileBoundsSystem : EntitySystem , IUpdateSystem
{
	Group<ProjectileComponent, PositionComponent> gProjPos;

	public override void SetGroups ()
	{
		gProjPos = Groups.GetGroup<ProjectileComponent, PositionComponent>();
	}


	public override void Update ()
	{
		gProjPos.Process( (ProjectileComponent proj, PositionComponent pos) => 
			{
				if (pos.position.y >  7f || 
					pos.position.y < -7f || 
					pos.position.x >  10 || 
					pos.position.x < -10)
				{
					pos.entity.Destroy();
				}


			});
	}

}
