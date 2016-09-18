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

	void OnAddView(ViewComponent view)
	{
		if (view.gameobject.GetComponent<EntityViewer>() == null)
			view.gameobject.AddComponent<EntityViewer>();
	}

	void OnRemoveView(ViewComponent view)
	{
		EntityViewer viewer = view.gameobject.GetComponent<EntityViewer>();
		if (viewer != null)
			GameObject.Destroy(viewer);
	}

}
