using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/HealthSystem")]
public class HealthSystem : EntitySystem
{
	public override void InitializeSystem ()
	{
		AddEvent<ResetEvent>(OnReset);
		AddEvent<DamageHealthEvent>(OnDamage);
	}


	void OnReset(Entity sender, Entity reciever, ResetEvent args)
	{
		var health = reciever.Get<HealthComponent>();
		health.CurrentHealth = health.MaxHealth;
	}

	void OnDamage(Entity sender, Entity reciever, DamageHealthEvent args)
	{
		var health = reciever.Get<HealthComponent>();
		if (health)
		{
			health.CurrentHealth -= args.amount;
			if (health.CurrentHealth <= 0)
				reciever.SendEvent(reciever, new DespawnEvent());
		}
	}
}

public class DamageHealthEvent
{
	public DamageHealthEvent (int amount)
	{
		this.amount = amount;
	}

	public int amount;
}

public class ResetEvent{}