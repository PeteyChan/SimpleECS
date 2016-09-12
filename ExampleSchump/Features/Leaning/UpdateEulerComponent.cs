using UnityEngine;
using System.Collections;
using ECS;

public class UpdateEulerAnglesSystem : EntitySystem , IUpdate
{
	Group<ViewComponent, EulerAnglesComponent> gViewEuler;

	public override void SetGroups ()
	{
		gViewEuler = Groups.GetGroup<ViewComponent, EulerAnglesComponent>();
	}

	public override void Update ()
	{
		gViewEuler.Process( (ViewComponent view, EulerAnglesComponent euler) => 
			{
				view.transform.localEulerAngles = euler.Angle;
			});
	}
}
