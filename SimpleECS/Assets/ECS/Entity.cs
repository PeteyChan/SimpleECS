using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SimpleECS.Internal;
#if UNITY_EDITOR
using UnityEditor;
#endif


[DisallowMultipleComponent]
public sealed class Entity : MonoBehaviour
{
	/// <summary>
	/// Unique Entity identifier, used when adding and removing Entities from Systems
	/// </summary>
	[ReadOnly, SerializeField]
	int id;
	public int ID
	{
		get {return id;}
	}

	ComponentHolder[] componentLookup;	// As far as I'm aware Arrays use more memory than Dictionary but are ALOT faster
										// this makes my Get<Component> calls faster than the Unity Implementation
										// Index to specific Components are found in the Group<C>.instance.ID
	// Entity Setup						// The reason for getting the ID's via Singleton is that it's very fast.
	void Awake()
	{
		if (!EntityManager.loaded)	// Ensure no code is run if no EntityManager
		{
			Debug.Log("Must Add Entity Manager to Use Entities");
			return;
		}
		EntityManager.instance.totalEntityCount ++;
		id = EntityManager.instance.GetEntityID;
		componentLookup = new ComponentHolder[EntityManager.instance.GetComponentCount()];
	}

	void OnDestroy()
	{
		if (EntityManager.loaded)
			EntityManager.instance.totalEntityCount --;
	}
		
	public ComponentHolder this[int key]	// Access Components based on their ComponentID
	{
		get
		{
			return componentLookup[key];
		}
		set
		{
			componentLookup[key] = value;
		}
	}
		
	/// <summary>
	/// Returns true if entity contains component
	/// </summary>
	public bool Has<C>() where C : EntityComponent<C>
	{
		return componentLookup[Group<C>.instance.ID].has;
	}

	/// <summary>
	/// Returns true if entity contains component and is enabled
	/// </summary>
	public bool HasEnabled<C>() where C : EntityComponent<C>
	{
		return componentLookup[Group<C>.instance.ID].enabled;
	}

	/// <summary>
	/// Returns true if has component. Outputs component
	/// </summary>
	public bool TryGet<C>(out C component) where C: EntityComponent<C>
	{
		ComponentHolder h = componentLookup[Group<C>.instance.ID];
		component = (C)h.component;
		return h.has;
	}

	/// <summary>
	/// Returns true if has component and enabled. Outputs component;
	/// </summary>
	public bool TryGetEnabled<C>(out C component) where C : EntityComponent<C>	// used to speed up systems a little bit
	{
		ComponentHolder h = componentLookup[Group<C>.instance.ID];
		component = (C)h.component;
		return h.enabled;
	}

	/// <summary>
	/// Returns Component if in variable, returns false 
	/// </summary>
	public C Get<C>() where C : EntityComponent<C>
	{
		return (C)componentLookup[Group<C>.instance.ID].component;
	}

	/// <summary>
	/// Returns Component or Adds and returns Component if None Found.
	/// </summary>
	public C GetOrAdd<C>() where C : EntityComponent<C>
	{
		var c = Get<C>();
		if (c == null) 
			c = gameObject.AddComponent<C>();
		return c;
	}

	/// <summary>
	/// Removes Component
	/// </summary>
	public void Remove<C>() where C : EntityComponent<C>
	{
		var c = Get<C>();
		if (c != null)
			Destroy(c);
	}

	/// <summary>
	/// Destroys this entity gameobject
	/// </summary>
	public void Destroy()
	{
		Destroy(gameObject);
	}

	public override bool Equals (object other)
	{
		if (other is Entity)
			return ((Entity)other).ID == ID;
		return false;
	}
		
	public override int GetHashCode ()
	{
		return ID; // since ID's are unique this is a no brainer
	}

	/// <summary>
	/// Calls Events on Entity that Match Argument's Type.
	/// </summary>
	public void SendEvent<E>(E args)
	{
		EntityManager.instance.CallEntityEvent(this, args);
	}
}

public static class EntityExtensions
{
	/// <summary>
	/// Returns owner Entity if one exists
	/// </summary>
	public static Entity GetEntity(this Collider col)
	{
		return col.gameObject.GetComponentInParent<Entity>();
	}

	/// <summary>
	/// Returns owner Entity if one exists
	/// </summary>
	public static Entity GetEntity(this GameObject go)
	{
		return go.GetComponentInParent<Entity>();
	}
}

namespace SimpleECS.Internal
{
	/// <summary>
	/// Small Stuct to make Component lookups fast
	/// </summary>
	[System.Serializable]
	public struct ComponentHolder
	{
		public bool has;
		public bool enabled;
		public EntityComponent component;
	}

	#if UNITY_EDITOR

	[CustomEditor(typeof(Entity))]
	public class EntityInspector: Editor
	{
		void OnEnable()
		{
			e = (Entity)target;
		}

		bool onlyEnabled;
		Entity e;

		bool refreshSearch;
		string lastSearch = "";
		string currentSearch = "";
		List<ComponentHolder> searchResults = new List<ComponentHolder>();
		List<ComponentHolder> allComponents = new List<ComponentHolder>();

		int DisplaySystemCount = 10;
		int index = 0;

		public override bool RequiresConstantRepaint ()
		{
			return true;
		}

		public override void OnInspectorGUI ()
		{
			if (Application.isPlaying && EntityManager.loaded)
			{
				allComponents.Clear();
				int componentCount = 0;
				int enabledCount = 0;

				for (int i = 0; i < EntityManager.instance.GetComponentCount(); ++i)
				{
					if (e[i].has)
					{
						componentCount++;
						if (e[i].enabled) enabledCount ++;
						else if (onlyEnabled) continue;

						allComponents.Add(e[i]);
					}

				}

				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
				EditorGUILayout.LabelField(string.Format("Entity ID : {0}", e.ID));
				EditorGUILayout.LabelField(string.Format("Total Components : {0}", componentCount));
				EditorGUILayout.LabelField(string.Format("Enabled Components : {0}", enabledCount));
				EditorGUILayout.LabelField(string.Format("Disabled Components : {0}", componentCount - enabledCount));

				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

				currentSearch = EditorGUILayout.TextField (new GUIContent("Search", "Perform filtering of Components"), currentSearch);					
				onlyEnabled = EditorGUILayout.Toggle("Only Enabled", onlyEnabled);

				var defaultColor = GUI.color;
				var disabledColor = GUI.color;
				disabledColor.a = .5f;

				if (!string.IsNullOrEmpty(currentSearch))
				{
					if (currentSearch != lastSearch || refreshSearch)
					{
						index = 0;
						searchResults.Clear();
						foreach (var item in allComponents)
						{
							if (onlyEnabled && !item.enabled) continue;

							if (item.component.GetType().ToString().IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) >= 0)
								searchResults.Add(item);
						}
					}
					DrawPrevAndNextButtons(ref index, searchResults.Count);
					for (int i = index; i < Mathf.Min(index + DisplaySystemCount, searchResults.Count); ++i)
					{
						DrawComponent(searchResults[i], disabledColor, defaultColor);	
					}
				}
				else
				{
					DrawPrevAndNextButtons(ref index, allComponents.Count);
					for (int i = index; i < Mathf.Min(index + DisplaySystemCount, allComponents.Count); ++i)
					{
						DrawComponent(allComponents[i], disabledColor, defaultColor);	
					}
				}
			}
			else 
				DrawDefaultInspector();
		}

		void DrawComponent(ComponentHolder item, Color disabledColor, Color defaultColor)
		{
			if (item.component == null)
			{
				refreshSearch = true;
				allComponents.Clear();
				return;
			}

			if (!item.enabled)
				GUI.color = disabledColor;
			
			EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);

			if (GUILayout.Button(DisplayStringWithSpaces(item.component.GetType().ToString()), EditorStyles.label, GUILayout.MaxWidth(Screen.width - 64f)))
			{
				EditorGUIUtility.PingObject(item.component);
			}	
			GUI.color = defaultColor;

			EditorGUILayout.EndHorizontal();
		}

	
		string DisplayStringWithSpaces(string text)
		{
			if (string.IsNullOrEmpty(text)) return text;

			System.Text.StringBuilder newText = new System.Text.StringBuilder(text.Length*2);
			newText.Append(text[0]);
			for(int i = 1; i < text.Length; ++i)
			{
				if (char.IsUpper(text[i]) && (char.IsLower(text[i-1])))
				{
					newText.Append(" ");	
				}
				newText.Append(text[i]);
			}
			return newText.ToString();
		}

		void DrawPrevAndNextButtons(ref int index, int componentCount)
		{
			EditorGUILayout.BeginHorizontal();

			if (componentCount >= DisplaySystemCount)
			{
				if (index >= DisplaySystemCount)
				{
					if (GUILayout.Button(string.Format("<- Previous {0}", DisplaySystemCount), GUILayout.MaxWidth(Screen.width/2f - 24f)))
						index -= DisplaySystemCount;

					if (index + 20 > componentCount)
					{
						GUI.enabled = false;
						GUILayout.Button(string.Format("Next {0} ->", DisplaySystemCount), GUILayout.MaxWidth(Screen.width/2f - 24f));
						GUI.enabled = true;
					}
				}
				if (index + DisplaySystemCount < componentCount)
				{
					if (index < DisplaySystemCount)
					{
						GUI.enabled = false;
						GUILayout.Button(string.Format("<- Previous {0}", DisplaySystemCount), GUILayout.MaxWidth(Screen.width/2f - 24f));
						GUI.enabled = true;
					}

					if (GUILayout.Button(string.Format("Next {0} ->", DisplaySystemCount), GUILayout.MaxWidth(Screen.width/2f - 24f)))
						index += DisplaySystemCount;
				}
			}
			EditorGUILayout.EndHorizontal();
		}
	}



	#endif
}