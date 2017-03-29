using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/BulletContact")]
public class BulletContact : EntitySystem
{
	public override void InitializeSystem ()
	{
		AddEvent<PlayerAttackEvent>(OnPlayerAttack);
		AddEvent<EnemyAttackEvent>(OnEnemyAttack);
	}

	void OnPlayerAttack(Entity sender, Entity reciever, PlayerAttackEvent args)
	{
		if (reciever.Has<EnemyComponent>())
		{
			reciever.SendEvent(sender, new DamageHealthEvent(1));
		}
	}

	void OnEnemyAttack(Entity sender, Entity reciever, EnemyAttackEvent args)
	{
		if (reciever.Has<PlayerComponent>())
		{
			reciever.SendEvent(sender, new DamageHealthEvent(1));
		}
	}
}

public class PlayerAttackEvent
{	
	public PlayerAttackEvent(BulletComponent b)
	{
		this.bullet = b;
	}
	public BulletComponent bullet;
}

public class EnemyAttackEvent
{
	public EnemyAttackEvent(BulletComponent b)
	{
		this.bullet = b;
	}
	public BulletComponent bullet;
}