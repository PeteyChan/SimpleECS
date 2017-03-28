using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public interface IUpdate{};
public interface IFixedUpdate{};

public class EntityManager : MonoBehaviour
{
	public static EntityManager instance;

	int ComponentCount = -1;
	Dictionary<System.Type, int> componentIDLookup = new Dictionary<System.Type, int>();
	Dictionary<Type, Group> groupLookup = new Dictionary<Type, Group>(); 
	Dictionary<int , object> entityEventLookup = new Dictionary<int, object>();	// stored here so it's cleaned up with this class

	public Action UpdateCallback = delegate {};
	public Action FixedUpdateCallback = delegate {};
		
	void Awake()
	{
		DontDestroyOnLoad(this);

		if (instance == null)
			instance = this;
		else DestroyImmediate(this);
	}

	void Update()
	{
		UpdateCallback();
	}

	void FixedUpdate()
	{
		FixedUpdateCallback();
	}

	int id;
	public int GetID
	{
		get {return ++id;}
	}

	public int GetComponentCount()
	{
		if (ComponentCount == -1)
		{
			var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
			foreach (var assembly in assemblies)
			{
				foreach(var type in assembly.GetTypes())
				{
					if (type.IsSubclassOf(typeof(EntityComponent)) && !type.IsAbstract)	//TODO Get types and put them in the lookup table, then make sure Groups have their ID's set
					{
						componentIDLookup.Add(type, componentIDLookup.Count);
					}
				}
			}
			ComponentCount = componentIDLookup.Count;
		}
		return ComponentCount;
	}

	public int GetEntityComponentID<C>()
	{
		int id;
		if (componentIDLookup.TryGetValue(typeof(C), out id))
			return id;
		return -1;
	}

	public Group<C> GetGroup<C>() where C : EntityComponent<C>
	{
		Group g;
		if (groupLookup.TryGetValue(typeof(C), out g))
			return (Group<C>)g;

		Group<C> newG = new Group<C>(GetEntityComponentID<C>());
		groupLookup.Add(typeof(C), newG);
		return newG;
	}

	void OnDestroy()
	{
		UpdateCallback = null;

		var Entities = FindObjectsOfType<Entity>();
		var EntitySystems = FindObjectsOfType<EntitySystem>();

		foreach (var entity in Entities)
		{
			Destroy(entity);
		}
		foreach (var system in EntitySystems)
		{
			Destroy(system);
		}
	}

	/// <summary>
	/// Entity Events
	/// </summary>

	public class EventHolder<E>
	{
		public EntityEvent<E> entityEvent = delegate{};
	}

	public class EventID
	{
		protected static int id;
	}

	public class EventID<C>:EventID
	{
		static bool hasID;
		static int _id;
		public static int ID
		{
			get
			{
				if (hasID) return _id;
				hasID = true;
				_id = id++;
				return _id;
			}
		}
	}

	public void AddEvent<E>(EntityEvent<E> callback)
	{
		object e;
		if (entityEventLookup.TryGetValue(EventID<E>.ID, out e))
		{
			((EventHolder<E>)e).entityEvent += callback;
			return;
		}

		EventHolder<E> newEvent = new EventHolder<E>();
		newEvent.entityEvent += callback;

		entityEventLookup.Add(EventID<E>.ID, newEvent);
	}

	public void RemoveEvent<E>(EntityEvent<E> callback)
	{
		object e;
		if (entityEventLookup.TryGetValue(EventID<E>.ID, out e))
		{	
			((EventHolder<E>)e).entityEvent -= callback;
		}
	}

	public void InvokeEvent<E>(Entity sender, Entity reciever, E args)
	{
		object e;
		if (entityEventLookup.TryGetValue(EventID<E>.ID, out e))
			((EventHolder<E>)e).entityEvent(sender, reciever, args);
	}
}
	
public class Group{}
public class Group<C>: Group where C : EntityComponent<C>
{
	public Group(int ID)
	{
		this.ID = ID;
	}

	static Group<C> _i;
	public static Group<C> instance
	{
		get 
		{
			if (_i == null)
			{
				_i = EntityManager.instance.GetGroup<C>();
			}
			return _i;
		}
	}

	public List<C> componentList = new List<C>();

	public System.Action<Entity> AddComponentCallback = delegate {};
	public System.Action<Entity> RemoveComponentCallback = delegate {};

	public void AddComponent(C c)
	{
		componentList.Add(c);
		AddComponentCallback(c.entity);
	}

	public void RemoveComponent(C c)
	{
		componentList.Remove(c);
		RemoveComponentCallback(c.entity);
	}

	public int ID;
}