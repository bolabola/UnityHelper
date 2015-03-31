using UnityEngine;
using UnityEditor;
using System.Collections;
/// <summary>
/// FBX导入设置 第一次导入时起作用
/// </summary>
public class FBXImportSettings : AssetPostprocessor
{

    private void OnPreprocessModel()
    {

        ModelImporter modelImporter = assetImporter as ModelImporter;

        modelImporter.animationType = ModelImporterAnimationType.None;
        modelImporter.generateSecondaryUV = false;

        Debug.Log("Importing model at: " + assetPath);
    }
}
