using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
/// <summary>
/// 
/// </summary>
public class GenerateResConfig : Editor
{
    [MenuItem("Tools/Res/GenerateResConfig")]
    public static void Generate() 
    {
        //������Դ�ļ�����
        //1.����Res����Ԥ�Ƽ�����·��GUID
        string[] resFiles = AssetDatabase.FindAssets("t:prefab", new string[]{"Assets/Resources"});
        for (int i = 0; i < resFiles.Length; i++)
        {
            resFiles[i] = AssetDatabase.GUIDToAssetPath(resFiles[i]);
            //2.���ɶ�Ӧ��ϵ
            string fileName = Path.GetFileNameWithoutExtension(resFiles[i]);
            string filePath = resFiles[i].Replace("Assets/Resources/",string.Empty).Replace(".prefab",string.Empty);
            resFiles[i] = fileName + "=" + filePath;
        }
        //3.д��
        File.WriteAllLines("Assets/StreamingAssets/ConfigMap.txt", resFiles);
        AssetDatabase.Refresh();
    }
}
