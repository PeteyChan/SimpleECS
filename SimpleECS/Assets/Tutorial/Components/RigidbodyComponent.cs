using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/RigidbodyComponent")]
public class RigidbodyComponent : EntityComponent<RigidbodyComponent>
{
	public Rigidbody Rigidbody;

	public Vector3 velocity
	{
		get
		{
			return Rigidbody.velocity;
		}
		set
		{
			Rigidbody.velocity = value;
		}
	}
}
