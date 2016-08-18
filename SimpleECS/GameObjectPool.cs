using UnityEngine;
using System.Collections.Generic;
using System;
using ECS.Internal;

	public static class GameObjectPool
	{
		static Dictionary<string, ObjectPool> _pools = new Dictionary<string, ObjectPool>();

		static Transform _p;
		static Transform _parent
		{
			get
			{
				if (_p == null)
				{
					_p = new GameObject("Object Pool").transform;
				}
				return _p;
			}
		}

		public static void Pool(this GameObject obj)
		{
			ObjectPool pool;
			obj.transform.parent = _parent;
			if (_pools.TryGetValue(obj.name, out pool) == false)
			{
				pool = new ObjectPool();
				_pools.Add(obj.name, pool);	
			}
			pool.PoolObject(obj);
		}


		//
		//	GET OBJECT METHODS
		//

		public static GameObject Get(GameObject go)
		{
			return Get(go.name);
		}

		public static GameObject Get(GameObject go, Transform parent)
		{
			return Get(go.name, parent);
		}

		public static GameObject Get(string path)
		{
			return Get (path, _parent);
		}

		/// <summary>
		/// Returns Prefab from path and sets it up using method
		/// </summary>
		public static GameObject Get(string path, Transform parent)
		{
			#if UNITY_EDITOR
			if (string.IsNullOrEmpty(path))
				Debug.LogError("Must provide a path to object file");
			#endif

			ObjectPool pool;
			if (_pools.TryGetValue(path, out pool) == false)
			{
				pool = new ObjectPool();
				_pools.Add(path, pool);
			}
			GameObject go = pool.GetObject(path);
			go.transform.parent = parent;
			go.SetActive(true);
			return go;
		}
	}	

namespace ECS.Internal
{

	public class ObjectPool
	{
		Stack<GameObject> _pool = new Stack<GameObject>();

		public void PoolObject(GameObject go)
		{
			go.SetActive(false);
			_pool.Push(go);
		}

		public GameObject GetObject(string path)
		{
			GameObject go;
			if (_pool.Count > 0)
			{
				go = _pool.Pop();
			}
			else
			{
				go = Resources.Load(path) as GameObject;
				go = GameObject.Instantiate(go) as GameObject;
				go.name = path;
			}
			return go;
		}
	}
}

