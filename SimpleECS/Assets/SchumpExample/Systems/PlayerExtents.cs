using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntitySystem/PlayerExtents")]
public class PlayerExtents : EntitySystem<PlayerComponent, RigidbodyComponent>, IUpdate
{
	public float MinX = -8f;
	public float MaxX = 8f;
	public float MinY = -3f;
	public float MaxY = 5.5f;

	public override void UpdateSystem (PlayerComponent player, RigidbodyComponent rigidbody)
	{
		Vector3 position = player.transform.position;

		bool hasMoved = false;

		if (position.x > MaxX)
		{
			position.x = MaxX;
			hasMoved = true;
		}
		if (position.y > MaxY)
		{
			position.y = MaxY;
			hasMoved = true;
		}
		if (position.x < MinX)
		{
			position.x = MinX;
			hasMoved = true;
		}	
		if (position.y < MinY)
		{
			position.y = MinY;
			hasMoved = true;
		}
			
		if (hasMoved)
			rigidbody.rb.MovePosition(position);

	}
}
