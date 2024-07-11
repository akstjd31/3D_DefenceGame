using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class ScriptableObjectLoader
{
    public static List<Structure> LoadAllStructures(string folderPath)
    {
        List<Structure> structures = new List<Structure>();

        // 폴더 내의 모든 asset 경로를 가져옴
        string[] guids = AssetDatabase.FindAssets("t:Structure", new[] { folderPath });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Structure obj = AssetDatabase.LoadAssetAtPath<Structure>(path);
            if (obj != null)
            {
                structures.Add(obj);
            }
        }

        return structures;
    }
}