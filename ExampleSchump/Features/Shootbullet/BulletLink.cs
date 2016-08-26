using UnityEngine;
using System.Collections;
using ECS;

public class BulletLink : EntityLink
{
	public override void SetUpComponents ()
	{
		entity
			.Add<ProjectileComponent>()
			.Set<MoveComponent>(speed)
			.Set<PositionComponent>(pos)

			;
	}


	public MoveComponent speed;
	public PositionComponent pos;

	void OnCollisionEnter(Collision collision)
	{
		EntityLink recieverlink = collision.gameObject.GetComponent<EntityLink>();
		if (recieverlink != null)
		{
			CustomEvent.Invoke(new CollisionEvent(entity, collision, recieverlink.entity));
		}


	}
}
