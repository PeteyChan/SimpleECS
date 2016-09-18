using UnityEngine;
using System.Collections;
using ECS;

public class ViewSystem : EntitySystem 
{
	public override void SetGroups ()
	{
		Groups.ListenAddEvent<ViewComponent>(OnAddView, true);
		Groups.ListenRemoveEvent<ViewComponent>(OnRemoveView, true);
	}

	void OnAddView(ViewComponent view)
	{
		if (view.entity.Has<ResourceComponent>())
		{
			ResourceComponent res = view.entity.Get<ResourceComponent>();
			view.gameobject = GameObjectPool.Get(res.path, view.entity);
			view.gameobject.name = res.path;
			view.transform.position = Vector3.zero;
		}
	}

	void OnRemoveView(ViewComponent view)
	{
		GameObjectPool.Pool(view.gameobject);
	}
}
