using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/SpawnEnemy")]
public class SpawnEnemy : EntitySystem, IUpdate
{
	public Entity Enemy;

	[Range(0.25f, 5f)]
	public float SpawnTimer = 1f;

	[Range (0, 10)]
	public int MaxSpawn = 5;


	float timer = 0;

	public int Poolcount;

	public override void UpdateSystem ()
	{
		if (timer > SpawnTimer && spawned < MaxSpawn)
		{
			Spawn(); timer = 0;
		}
		timer += Time.deltaTime;
	}

	int spawned;

	void Spawn()
	{
		spawned ++;
		var go = GameObjectPool.Get(Enemy.gameObject);
		go.transform.position = transform.position;
		go.transform.rotation = Quaternion.identity;

		go.GetComponentInParent<Entity>().SendEvent(null, new ResetEvent());
	}

	public override void InitializeSystem ()
	{
		AddEvent<DespawnEvent>(OnDespawn);
	}

	void OnDespawn(Entity sender, Entity reciever, DespawnEvent args)
	{
		if (!reciever.enabled) return;

		GameObjectPool.Pool(reciever.gameObject);
		if (reciever.Has<EnemyComponent>())
		{
			spawned --;
			if (spawned < 0) spawned = 0;	
		}
	}
}

public class DespawnEvent{}