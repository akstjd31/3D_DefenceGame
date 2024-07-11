using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StructureSO", menuName = "Scriptable Object/StructureSO", order = int.MaxValue)]
public class StructureSO : ScriptableObject
{
    public Structure[] structures;
}
