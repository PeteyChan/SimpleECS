using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using System;


namespace ECS.Internal
{
	public class NewTemplates: Editor
	{
		[MenuItem ("ECS/New Entity Component"), MenuItem("Assets/Create/ECS/New Entity Component", false, 50)]
		static void NewEntityComponent()
		{
			CreateTextAsset("NewEntityComponent", "NewComponent.txt");
		}

		[MenuItem ("ECS/New Entity System"), MenuItem("Assets/Create/ECS/New Entity System", false, 51)]
		static void NewEntitySystem()
		{
			CreateTextAsset("NewEntitySystem", "NewSystem.txt");
		}

		[MenuItem ("ECS/New Entity Link"), MenuItem("Assets/Create/ECS/New Entity Link", false, 52)]
		static void NewEntityLink()
		{
			CreateTextAsset("NewEntityLink", "NewLink.txt");
		}


		static void CreateTextAsset(string name, string assetName)
		{
			TextAsset asset = Resources.Load(assetName) as TextAsset;
			string text = asset.text;

			text = text.Replace("#SCRIPTNAME#", name);

			string writePath = "Assets/";
			if (Selection.activeObject)
			{
				writePath = AssetDatabase.GetAssetPath(Selection.activeObject);
			}

			var writePathInfo = new FileInfo( writePath );

			//Check if write path is on directory or folder
			var fullWritePath = "";
			var writeAttr = File.GetAttributes( writePath );
			if( writeAttr  == FileAttributes.Directory )
			{
				fullWritePath = writePathInfo.ToString();
			}
			else
			{
				fullWritePath = writePathInfo.Directory.ToString();
			}

			fullWritePath += string.Format("\\{0}.cs", name);
			File.WriteAllText( fullWritePath, text);

			AssetDatabase.Refresh();
		}
	}			
}


