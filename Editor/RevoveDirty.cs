using UnityEngine;
using UnityEditor;
/// <summary>
/// 删除场景没用的MeshCollider和Animation"
/// </summary>
public class RevoveDirty:Editor
{
    [MenuItem("Tools/Revove_MeshCollider&Animation")]
    static public void Remove()
    {
        //获取当前场景里的所有游戏对象
        GameObject[] rootObjects = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
        //遍历游戏对象
        foreach (GameObject go in rootObjects)
        {
            //如果发现Render的shader是Diffuse并且颜色是白色，那么将它的shader修改成Mobile/Diffuse
            if (go != null && go.transform.parent != null)
            {
                Renderer render = go.GetComponent<Renderer>();
                if (render != null && render.sharedMaterial != null && render.sharedMaterial.shader.name == "Diffuse" && render.sharedMaterial.color == Color.white)
                {
                    render.sharedMaterial.shader = Shader.Find("Mobile/Diffuse");
                }
            }

            //删除所有的MeshCollider
            foreach (MeshCollider collider in UnityEngine.Object.FindObjectsOfType(typeof(MeshCollider)))
            {
                DestroyImmediate(collider);
            }

            //删除没有用的动画组件
            foreach (Animation animation in UnityEngine.Object.FindObjectsOfType(typeof(Animation)))
            {
                if (animation.clip == null)
                    DestroyImmediate(animation);
            }

            //应该没有人用Animator吧？ 避免美术弄错我都全部删除了。
            foreach (Animator animator in UnityEngine.Object.FindObjectsOfType(typeof(Animator)))
            {
                DestroyImmediate(animator);
            }
        }
        //保存
        AssetDatabase.SaveAssets();
    }
}