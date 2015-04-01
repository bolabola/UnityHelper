﻿using UnityEngine;
using UnityEditor;
using System.Collections;
/// <summary>
/// 在导入FBX前将脚本放置在Editor文件夹中
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
    //导入后在当前目录自动创建prefab
    private void OnPostprocessModel(GameObject go)
    {
        PrefabUtility.CreatePrefab(assetPath.Replace(".FBX", ".prefab"), go);
    }
}
