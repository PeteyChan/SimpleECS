using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/RigidbodyComponent")]
public class RigidbodyComponent : EntityComponent<RigidbodyComponent>
{
	public Rigidbody rb;

	// use properties to make setting values easier
	public Vector3 velocity
	{
		get
		{
			return rb.velocity;
		}
		set
		{
			rb.velocity = value;
		}
	}
}
