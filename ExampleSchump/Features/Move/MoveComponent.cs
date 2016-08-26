using UnityEngine;
using System.Collections;
using ECS;

[System.Serializable]
public class MoveComponent : EntityComponent
{
	float _xAxis = 0;
	[HideInInspector]
	public float xAxis
	{
		get{return _xAxis;}
		set{_xAxis = Mathf.Clamp(value, -1f, 1f);}
	}

	float _yAxis = 0;
	[HideInInspector]
	public float yAxis
	{
		get{return _yAxis;}
		set{_yAxis = Mathf.Clamp(value, -1f, 1f);}
	}

	public float speed = 1;
}
