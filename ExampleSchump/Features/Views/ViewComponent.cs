using UnityEngine;
using ECS;

[System.Serializable]
public class ViewComponent: EntityComponent
{
	GameObject _go;
	public GameObject gameobject
	{
		get{return _go;}
		set
		{
			transform = value.transform;
			_go = value;
		}
	}
	public Transform transform;
}
