using UnityEngine;
using System.Collections;
using ECS;

public class SpawnEnemySystem : EntitySystem , IUpdate
{
	int MaxEnemies = 4;
	float RespawnTimer = 0;

	Group<EnemyComponent> gEnemies;

	public override void SetGroups ()
	{
		gEnemies = Groups.GetGroup<EnemyComponent>();
	}

	public override void Update ()
	{
		if (gEnemies.EntityCount < MaxEnemies)
		{
			RespawnTimer -= Time.deltaTime;
			if (RespawnTimer <= 0)
			{
				SpawnEnemy(1);
				RespawnTimer = 1f;
				//Debug.Log(gEnemies.EntityCount);
			}
		}
	}

	void SpawnEnemy(int amount)
	{
		for (int i = 0; i < amount ; ++i)
		{
			Entity e = Entity.Create();
			e.GetAdd<ResourceComponent>().path = Loader.Enemy;
			e.Add<ViewComponent>();	
		}
	}


}
