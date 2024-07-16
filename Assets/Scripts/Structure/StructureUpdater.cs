using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class StructureUpdater : MonoBehaviour
{
    [MenuItem("Tools/Update Structure List")]
    public static void UpdateStructureList()
    {
        // StructureSO 파일의 경로를 지정합니다.
        string structureSOPath = "Assets/ScriptableObject/StructureSO.asset";

        // StructureSO 파일을 로드하거나 생성합니다.
        StructureSO structureSO = AssetDatabase.LoadAssetAtPath<StructureSO>(structureSOPath);
        if (structureSO == null)
        {
            structureSO = ScriptableObject.CreateInstance<StructureSO>();
            AssetDatabase.CreateAsset(structureSO, structureSOPath);
        }

        // 특정 폴더 내의 모든 Structure 파일들을 찾습니다.
        string[] guids = AssetDatabase.FindAssets("t:Structure", new[] { "Assets/ScriptableObject" });
        List<Structure> structures = new List<Structure>();

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Structure structure = AssetDatabase.LoadAssetAtPath<Structure>(path);
            if (structure != null)
            {
                structures.Add(structure);
            }
        }

        // StructureSO 파일의 리스트를 갱신합니다.
        structureSO.structures = structures;

        // 변경사항을 저장하고 에셋 데이터베이스를 갱신합니다.
        EditorUtility.SetDirty(structureSO);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Structure list updated successfully!");
    }
}