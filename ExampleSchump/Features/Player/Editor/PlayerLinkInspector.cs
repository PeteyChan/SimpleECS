using UnityEngine;
using System.Collections;
using UnityEditor;
using ECS;

[CustomEditor(typeof(PlayerLink))]
public class PlayerLinkInspector : Editor 
{
	bool foldout = false;

	public override void OnInspectorGUI ()
	{
		if (!Application.isPlaying)
		{
			DrawDefaultInspector();
			return;
		}

		Entity e = ((EntityLink)target).entity;

		foldout = EditorGUILayout.Foldout(foldout, string.Format("Entity {0}", e.ID));
		if (foldout)
			ECSInspector.ListComponents(e);
		DrawDefaultInspector();
	}

}
