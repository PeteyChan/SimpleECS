using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectPool : MonoBehaviour
{
	public Dictionary<string, Stack<GameObject>> ObjectPools = new Dictionary<string, Stack<GameObject>>();

	static GameObjectPool _i;
	static GameObjectPool instance
	{
		get 
		{
			if (_i == null)
			{
				if (OnQuit) return null;
				GameObject Go = new GameObject("ObjectPool");
				_i = Go.AddComponent<GameObjectPool>();
			}
			return _i;
		}
	}
		
	void Awake()
	{
		OnQuit = false;
	}

	static bool OnQuit = false;

	void OnApplicationQuit()
	{
		OnQuit = true;
	}

	public static GameObject Get(GameObject go)
	{
		if (OnQuit) return null;

		Stack<GameObject> pool;
		GameObject newGo;
		if (instance.ObjectPools.TryGetValue(go.name, out pool))
		{
			if (pool.Count > 0)
			{
				newGo = pool.Pop();	
			}
			else
			{
				newGo = Instantiate(go) as GameObject;
				newGo.transform.parent = instance.transform;
			}
		}
		else 
		{
			newGo = Instantiate(go) as GameObject;
			newGo.transform.parent = instance.transform;
		}
		newGo.name = go.name;
		newGo.SetActive(true);
		return newGo;
	}

	public static void Pool(GameObject go)
	{
		if (OnQuit) return;

		Stack<GameObject> pool;
		if (!instance.ObjectPools.TryGetValue(go.name, out pool))
		{
			pool = new Stack<GameObject>();
			instance.ObjectPools[go.name] = pool;
		}
		pool.Push(go);
		go.transform.parent = instance.transform;
		go.SetActive(false);
	}

	public static void ClearPools()
	{
		instance.ObjectPools.Clear();
	}
}


