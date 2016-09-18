using UnityEngine;
using System.Collections;
using ECS;

public class SpawnPlayerSystem : EntitySystem , IUpdate
{
	Entity player;

	public override void OnEnable ()
	{
		SpawnPlayer();
	}

	public override void OnDisable ()
	{
		player.Destroy();
	}

	public override void Update ()
	{
		if (Input.GetKeyDown(KeyCode.I))
			SpawnPlayer();
	}

	void SpawnPlayer()
	{
		player = Entity.Create();
		player.GetAdd<ResourceComponent>().path = Loader.SpaceShip;
		player.Add<ViewComponent>();
	}

}
