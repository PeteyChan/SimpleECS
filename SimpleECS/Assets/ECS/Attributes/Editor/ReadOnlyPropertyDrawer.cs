using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(ReadOnly))]
public class ReadOnlyPropertyDrawer : PropertyDrawer
{
	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return EditorGUI.GetPropertyHeight(property, label);
	}

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		GUI.enabled = false;
		EditorGUI.PropertyField(position, property, label, true);
		GUI.enabled = true;
	}
}
