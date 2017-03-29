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
		AddEvent<ResetEvent>(OnReset);
	}

	/// <summary>
	/// While Updating apply shake formula
	/// </summary>
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

	/// <summary>
	/// When object is reset, turn off shake compoennt
	/// </summary>
	void OnReset(Entity sender, Entity reciever, ResetEvent args)
	{
		var shake = reciever.Get<ShakeComponent>();

		if (shake.enabled)
			shake.enabled = false;
	}

	/// <summary>
	/// Enables the shake component when recieving the event
	/// </summary>
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
