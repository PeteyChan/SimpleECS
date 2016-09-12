using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ECS.Internal
{
	[CustomEditor(typeof(EntityViewer))]
	public class EntityViewerInspector : Editor 
	{
		public override void OnInspectorGUI ()
		{
			Entity e = ((EntityViewer)target).entity;

			if (e == null)
			{
				EditorGUILayout.LabelField("No Entity Attached to GameObject");
				return;
			}
			EditorGUILayout.LabelField(string.Format("Entity {0}", e.ID));
			ECSInspector.ListComponents(e);
			EditorUtility.SetDirty(target);
		}
	
	}

}