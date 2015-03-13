using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
/// <summary>
/// fbx放在资源根目录的fbx文件夹中，脚步会遍历该目录，将fbx转成prefab放在子目录prefab中
/// </summary>
public class FbxToPrefab : Editor {
    [MenuItem("Tool/FbxToPrefab")]
    static void FTP()
    {
        
        //GameObject[] o = AssetDatabase.LoadAllAssetsAtPath("Assets/fbx/") as GameObject[];
        //这里不能使用AssetDatabase.LoadAllAssetsAtPath是因为这个方法并不是加载目录中的所有资源，而是用于一个go包含多个mesh的情况，具体看官网描述和下面链接
        //http://forum.unity3d.com/threads/loadallassetsatpath.21444/
        //http://forum.unity3d.com/threads/how-to-get-list-of-assets-at-asset-path.18898/
        GameObject[] o = GetAtPath<GameObject>("fbx/");

        if (!Directory.Exists(Application.dataPath+ "/fbx/prefab"))
            Directory.CreateDirectory(Application.dataPath + "/fbx/prefab");

        foreach (GameObject go in o)
        {
            PrefabUtility.CreatePrefab( "Assets/fbx/prefab/" + go.name + ".prefab", go);
        }
        AssetDatabase.Refresh();
    }
     static T[] GetAtPath<T>(string path)
    {

        ArrayList al = new ArrayList();
        string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);

        foreach (string fileName in fileEntries)
        {
            int assetPathIndex = fileName.IndexOf("Assets");
            string localPath = fileName.Substring(assetPathIndex);

            Object t = Resources.LoadAssetAtPath(localPath, typeof(T));

            if (t != null)
                al.Add(t);
        }
        T[] result = new T[al.Count];
        for (int i = 0; i < al.Count; i++)
            result[i] = (T)al[i];

        return result;
    }
}
