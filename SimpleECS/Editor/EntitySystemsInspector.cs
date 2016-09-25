using UnityEngine;
using System.Collections;
using ECS;
using UnityEditor;

namespace ECS.Internal
{	
	[UnityEditor.CustomEditor(typeof(EntitySystems))]
	public class EntitySystemsInspector : Editor
	{
		public override void OnInspectorGUI ()
		{
			if (Application.isPlaying)
			{
				SystemManager();
			}
			else
				EditorGUILayout.LabelField("No Current Systems");
			EditorUtility.SetDirty(target);
		}

		public void SystemManager()
		{
			EntitySystems systems = (EntitySystems)target;
			EditorGUILayout.Separator();
			EditorGUI.indentLevel ++;
			EditorGUILayout.LabelField(string.Format("Active Entities : {0}", Entity.ActiveEntitiesCount()));
			EditorGUILayout.LabelField(string.Format("Total Groups : {0}", Groups.Count()));
			EditorGUILayout.LabelField(string.Format("Systems : {0}", systems._systemLookup.Count ));
			EditorGUILayout.LabelField(string.Format("Update Systems : {0}", systems._updateSystems.Count ));
			EditorGUILayout.LabelField(string.Format("Fixed Update Systems : {0}", systems._fixedUpdateSystems.Count ));
			EditorGUI.indentLevel --;
			EditorGUILayout.Separator();
			foreach(var systemGroup in systems._systemGroups.Values)
			{
				systemGroup.enabled = EditorGUILayout.Foldout(systemGroup.enabled, systemGroup.name);
				if (systemGroup.enabled)
				{
					EditorGUI.indentLevel ++;
					foreach(var system in systemGroup.systems)
					{
						EditorGUILayout.BeginHorizontal();
						string name = system.GetType().ToString();
						if (name.EndsWith("System"))
							name = name.Substring(0, name.Length-6);
						name = name.Replace("_", " ");
						system.enabled = EditorGUILayout.ToggleLeft( name, system.enabled, GUILayout.MaxWidth(Screen.width/2f-15f));
						if (system is IUpdate)
							EditorGUILayout.LabelField(" :Update", GUILayout.MaxWidth( Screen.width/4f));
						if (system is IFixedUpdate)
							EditorGUILayout.LabelField(" :Fixed ", GUILayout.MaxWidth( Screen.width/4f));

						EditorGUILayout.EndHorizontal();	
					}
					EditorGUI.indentLevel --;
				}
			}
		}
	}
}