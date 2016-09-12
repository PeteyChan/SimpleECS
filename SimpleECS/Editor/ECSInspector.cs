using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using ECS.Internal;

namespace ECS
{
	public class ECSInspector : Editor
	{
		/// <summary>
		/// Only Updates if set dirty
		/// </summary>
		public static void SystemManager()
		{
			EditorGUILayout.LabelField("SystemManager", EditorStyles.boldLabel);
			EditorGUILayout.Separator();
			EditorGUI.indentLevel ++;
			EditorGUILayout.LabelField(string.Format("Active Entities : {0}", Entity.ActiveEntitiesCount()));
			EditorGUILayout.LabelField(string.Format("Systems : {0}", EntitySystemManager.SystemsCount));
			EditorGUILayout.LabelField(string.Format("Update Systems : {0}", EntitySystemManager.UpdateSystemsCount));
			EditorGUILayout.LabelField(string.Format("Fixed Update Systems : {0}", EntitySystemManager.FixedUpdateSystemsCount));
			EditorGUI.indentLevel --;
			EditorGUILayout.Separator();
			foreach(var systemGroup in ECSManager._systemGroups.Values)
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
						if (name.StartsWith("S_"))
							name = name.Substring(2);
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

		public static void ListComponents(Entity e)
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
					if (name.StartsWith("C_"))
						name = name.Substring(2);
					EditorGUILayout.LabelField(name);
				}
			}
			EditorGUI.indentLevel --;
		}
	}

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
			if (Application.isPlaying)
				ECSInspector.ListComponents(e);
		}
	}
}