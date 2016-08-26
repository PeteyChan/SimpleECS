using UnityEngine;
using System.Collections;
using ECS;

public class MoveInputComponent : EntityComponent 
{
	public float xAxis
	{
		get {return Input.GetAxis("Horizontal");}
	}
	public float yAxis
	{
		get {return Input.GetAxis("Vertical");}
	}
}
