using UnityEngine;
using System.Collections;
using ECS;

public class ViewSystem : EntitySystem 
{
	public override void SetGroups ()
	{
		Groups.AddComponentEvent<ViewComponent>(OnAddView, true);
		Groups.RemoveComponentEvent<ViewComponent>(OnRemoveView, true);
	}

	void OnAddView(Entity e)
	{
		if (e.Has<ResourceComponent>())
		{
			ViewComponent view = e.Get<ViewComponent>();
			ResourceComponent res = e.Get<ResourceComponent>();
			view.gameobject = GameObjectPool.Get(res.path, e);
			view.gameobject.name = res.path;
			view.transform.position = Vector3.zero;
		}
	}

	void OnRemoveView(Entity e)
	{
		GameObjectPool.Pool(e.Get<ViewComponent>().gameobject);
	}
}
