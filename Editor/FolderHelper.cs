/// <summary>
/// Create Files just by one click.
/// </summary>
using UnityEngine;
using UnityEditor;
using System.IO;
class FolderHelper: MonoBehaviour
{
		[MenuItem("Tool/FilesCreate")]
	
		static void CreateFolder ()
		{
				string[] str = {"Resources",
									"Scripts",
									"Prefab",
									"Textures",
									"Plugins",
									"Scene",
									"Material"};
				foreach (string s in str) {
						if (!Directory.Exists (Application.dataPath + "/" + s)) {
								Directory.CreateDirectory (Application.dataPath + "/" + s);
						}
				}
				AssetDatabase.Refresh ();
		}
}