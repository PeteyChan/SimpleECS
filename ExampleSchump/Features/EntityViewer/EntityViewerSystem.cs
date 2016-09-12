using UnityEngine;
using System.Collections;
using ECS;

public class EntityViewerSystem : EntitySystem 
{
	public override void OnEnable ()
	{
		EntityLink[] links = GameObject.FindObjectsOfType<EntityLink>();
		foreach(var link in links)
			link.gameObject.AddComponent<EntityViewer>();

		Groups.ListenAddEvent<ViewComponent>(OnAddView, true);
		Groups.ListenRemoveEvent<ViewComponent>(OnRemoveView, true);
	}

	public override void OnDisable ()
	{
		EntityViewer[] viewers = GameObject.FindObjectsOfType<EntityViewer>();
		foreach(var viewer in viewers)
			GameObject.Destroy(viewer);

		Groups.ListenAddEvent<ViewComponent>(OnAddView, false);
		Groups.ListenRemoveEvent<ViewComponent>(OnRemoveView, false);
	}

	void OnAddView(Entity e)
	{
		ViewComponent view = e.Get<ViewComponent>();
		if (view.gameobject.GetComponent<EntityViewer>() == null)
			view.gameobject.AddComponent<EntityViewer>();
	}

	void OnRemoveView(Entity e)
	{
		ViewComponent view = e.Get<ViewComponent>();
		EntityViewer viewer = view.gameobject.GetComponent<EntityViewer>();
		if (viewer != null)
			GameObject.Destroy(viewer);
	}

}
