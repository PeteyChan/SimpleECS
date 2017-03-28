using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Shakes Entity when Health is damaged
/// </summary>
[AddComponentMenu("EntitySystem/ShakeSystem")]
public class ShakeSystem : EntitySystem<ShakeComponent>, IUpdate
{
	public override void InitializeSystem ()
	{
		AddEvent<DamageHealthEvent>(OnHealthDamage);
		AddEvent<DespawnEvent>(OnDespawn);
	}

	public override void UpdateSystem (ShakeComponent shake)
	{
		shake.currentShakeTime += Time.deltaTime;

		shake.transform.eulerAngles += Mathf.Sin(Time.time*shake.shakeSpeed)* new Vector3(0,0,shake.shakeAmount);

		if (shake.currentShakeTime > shake.maxShakeTime)
		{
			shake.enabled = false;
			shake.transform.rotation = Quaternion.identity;
		}
	}

	void OnDespawn(Entity sender, Entity reciever, DespawnEvent args)
	{
		var shake = reciever.Get<ShakeComponent>();

		if (shake)
			shake.enabled = false;
	}

	void OnHealthDamage(Entity sender, Entity reciever, DamageHealthEvent args)
	{
		var shake = reciever.Get<ShakeComponent>();
		if (shake)
		{
			shake.enabled = true;
			shake.currentShakeTime = 0;
		}
	}
}
