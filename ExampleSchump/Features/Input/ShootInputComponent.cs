using UnityEngine;
using System.Collections;
using ECS;

public class ShootInputComponent : EntityComponent
{
	public bool shoot
	{
		get
		{
			return Input.GetButton("Fire1");
		}
	}
}
