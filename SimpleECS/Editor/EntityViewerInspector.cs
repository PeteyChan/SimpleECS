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
			if (!Application.isPlaying)
				return;

			Entity e = ((EntityViewer)target).entity;

			if (e == null)
			{
				EditorGUILayout.LabelField("No Entity Attached to GameObject");
				return;
			}
			EditorGUILayout.LabelField(string.Format("Entity {0}", e.ID));
			ListComponents(e);
			EditorUtility.SetDirty(target);
		}
	
		public void ListComponents(Entity e)
		{
			if (e == null)
				return;
			int count = 0;
			EditorGUI.indentLevel ++;
			for (int i = 0; i < ECSManager.UniqueComponentCount(); ++i)
			{
				if (e.Has(i))
				{
					count ++;
					string name = string.Format("{0} : {1}", count ,ECSManager.GetComponentType(i));
					if (name.EndsWith("Component"))
						name = name.Substring(0, name.Length - 9);
					name = name.Replace("_", " ");
					EditorGUILayout.LabelField(name);
				}
			}
			EditorGUI.indentLevel --;
		}
	}

}