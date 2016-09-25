using UnityEngine;
using System.Collections.Generic;
using System;
using ECS.Internal;

namespace ECS
{
	public class GameObjectPool : MonoBehaviour
	{
		public bool loaded = true;
		static GameObjectPool _i;
		static GameObjectPool Instance
		{
			get
			{
				if (_i == null)
				{
					_i = new GameObject("GameObject Pool").AddComponent<GameObjectPool>();
				}
				return _i;
			}
		}

		public Dictionary<string, ObjectPool> pools = new Dictionary<string, ObjectPool>();

		public static void Pool(GameObject obj)
		{
			if (Instance.loaded == false)
				return;
			
			ObjectPool pool;
			obj.transform.parent = Instance.transform;
			if (Instance.pools.TryGetValue(obj.name, out pool) == false)
			{
				pool = new ObjectPool();
				Instance.pools.Add(obj.name, pool);	
			}
			pool.PoolObject(obj);
		}

		/// <summary>
		/// Returns Prefab from path and sets it up using method
		/// </summary>
		public static GameObject Get(string path, Entity e)
		{
			#if UNITY_EDITOR
			if (string.IsNullOrEmpty(path))
				Debug.LogError("Must provide a path name to object file");
			#endif

			if (Instance.loaded == false)
				return null;

			ObjectPool pool;
			if (Instance.pools.TryGetValue(path, out pool) == false)
			{
				pool = new ObjectPool();
				Instance.pools.Add(path, pool);
			}
			GameObject go = pool.GetObject(path);
			go.transform.parent = Instance.transform;
			go.SetActive(true);

			EntityLink link = go.GetComponent<EntityLink>();	// Add Entity Link and Set up components
			if (link == null)
				link = go.AddComponent<EntityLink>();
			link.SetEntity(e);
			link.SetUpComponents();
			if (link.SetUpComponentsEvent != null)
				link.SetUpComponentsEvent(e);
			return go;
		}

		public static int poolCount()
		{
			return Instance.pools.Count;
		}

		void OnDestroy()
		{
			Instance.loaded = false;
		}

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