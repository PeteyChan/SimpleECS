using UnityEngine;
using System.Collections;
using ECS;
using UnityEditor;

namespace ECS.Internal
{	
	[UnityEditor.CustomEditor(typeof(SystemsViewer))]
	public class SystemsViewerInspector : Editor
	{
		public override void OnInspectorGUI ()
		{
			if (Application.isPlaying)
			{
				ECSInspector.SystemManager();
			}
			else
				EditorGUILayout.LabelField("No Current Systems");
			EditorUtility.SetDirty(target);
		}
	}
}