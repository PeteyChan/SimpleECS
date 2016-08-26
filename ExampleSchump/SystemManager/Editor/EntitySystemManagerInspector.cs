using UnityEngine;
using System.Collections;
using ECS;
using UnityEditor;

[UnityEditor.CustomEditor(typeof(SystemInterface))]
public class SystemInterfaceInspector : UnityEditor.Editor
{
	EntitySystemManager manager;

	public void OnEnable()
	{
		manager = ((SystemInterface)target).Manager;
	}

	public override void OnInspectorGUI ()
	{
		if (Application.isPlaying)
			ECSInspector.SystemManager(manager);
		else
			DrawDefaultInspector();
		EditorUtility.SetDirty(target);
	}
}
