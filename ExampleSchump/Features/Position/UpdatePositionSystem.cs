using UnityEngine;
using System.Collections;
using ECS;

public class UpdatePositionSystem : EntitySystem, IUpdateSystem
{
	Group<ViewComponent, PositionComponent> gViewPos;

	public override void SetGroups ()
	{
		gViewPos = Groups.GetGroup<ViewComponent, PositionComponent>();
	}
		
	public override void Update ()
	{
		gViewPos.Process( (ViewComponent view, PositionComponent pos) => 
			{
				view.transform.position = pos.position;	
			});
	}
}
