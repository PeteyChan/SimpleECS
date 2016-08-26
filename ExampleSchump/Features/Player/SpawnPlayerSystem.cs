using UnityEngine;
using System.Collections;
using ECS;

public class SpawnPlayerSystem : EntitySystem 
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

	void SpawnPlayer()
	{
		player = Entity.CreateEntity();
		player.GetAdd<ResourceComponent>().path = Loader.SpaceShip;
		player.Add<ViewComponent>();
	}

}
