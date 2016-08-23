using UnityEngine;
using System.Collections;
using ECS;
using ECS.Internal;

#if UNITY_EDITOR
using UnityEditor;
#endif

// used to link unity gameobjects into Simple ECS
public class EntityLink : MonoBehaviour 
{
	//[SerializeField]
	Entity _entity;
	public Entity entity
	{
		get
		{
			if (_entity == null)
				_entity = Entity.CreateEntity();
			return _entity;
		}
	}

	public void SetEntity(Entity e)
	{
		_entity = e;
	}

	public virtual void SetUpComponents()
	{}
}


#if UNITY_EDITOR
[CustomEditor(typeof(EntityLink))]
public class EntityLinkInspector : Editor
{
	Entity e;

	void OnEnable()
	{
		e = (target as EntityLink).entity;
	}

	public override void OnInspectorGUI ()
	{
		EntityInspector.InspectEntity(e);
	}
}
#endif

#if UNITY_EDITOR
public class EntityInspector : Editor
{
	public static void InspectEntity(Entity e)
	{
		if (e == null)
			return;
		EditorGUILayout.LabelField(string.Format("Entity {0}", e.ID), EditorStyles.boldLabel);
		EditorGUI.indentLevel ++;
		for (int i = 0; i < EntityManager.UniqueComponentCount(); ++i)
		{
			if (e.Has(i))
				EditorGUILayout.LabelField(EntityManager.GetComponentType(i).ToString());
		}
		EditorGUI.indentLevel --;
	}
}
#endif

