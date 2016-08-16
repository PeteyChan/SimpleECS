using UnityEngine;
using System.Collections;
using ECS;
using ECS.Internal;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class EntityLink : MonoBehaviour 
{
	public Entity Entity;
}

#if UNITY_EDITOR
[CustomEditor(typeof(EntityLink))]
public class EntitlyLinkInspector : Editor
{
	Entity e;

	void OnEnable()
	{
		e = ((EntityLink)target).Entity;
	}

	public override void OnInspectorGUI ()
	{
		EditorGUILayout.LabelField( string.Format("Entity {0} ", e.ID), EditorStyles.boldLabel);
		EditorGUI.indentLevel ++;
		for (int i =0; i < EntityPool.GetTotalUniqueComponetTypes(); ++i)
		{
			if (e.Has(i))
				EditorGUILayout.LabelField(EntityPool.GetComponentType(i).ToString());
		}
		EditorGUI.indentLevel --;
	}
}
#endif

