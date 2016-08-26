using UnityEngine;
using System.Collections;
using UnityEditor;
using ECS.Internal;

namespace ECS
{
	public class ECSInspector : Editor
	{
		/// <summary>
		/// Only Updates if set dirty
		/// </summary>
		public static void SystemManager(EntitySystemManager manager)
		{
			EditorGUILayout.LabelField("SystemManager", EditorStyles.boldLabel);
			EditorGUILayout.Separator();
			EditorGUI.indentLevel ++;
			EditorGUILayout.LabelField(string.Format("Active Entities : {0}", Entity.ActiveEntitiesCount()));
			EditorGUILayout.LabelField(string.Format("Systems : {0}", EntitySystemManager.SystemsCount));
			EditorGUILayout.LabelField(string.Format("Update Systems : {0}", EntitySystemManager.UpdateSystemsCount));
			EditorGUI.indentLevel --;
			EditorGUILayout.Separator();
			foreach(var system in EntitySystemManager._systems)
			{
				EditorGUILayout.BeginHorizontal();
				string name = system.GetType().ToString();
				if (name.EndsWith("System"))
					name = name.Substring(0, name.Length-6);
				system.enabled = EditorGUILayout.ToggleLeft( name, system.enabled);
				if (system is IUpdateSystem)
					EditorGUILayout.LabelField(" : UpdateSystem");
				EditorGUILayout.EndHorizontal();
			}
		}

		public static void ListComponents(Entity e)
		{
			if (e == null)
				return;
			int count = 0;
			EditorGUI.indentLevel ++;
			for (int i = 0; i < EntityManager.UniqueComponentCount(); ++i)
			{
				if (e.Has(i))
				{
					count ++;
					string name = string.Format("{0} : {1}", count ,EntityManager.GetComponentType(i));
					if (name.EndsWith("Component"))
						name = name.Substring(0, name.Length - 9);
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