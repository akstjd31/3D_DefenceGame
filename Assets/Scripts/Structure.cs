using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Structure", menuName = "Scriptable Object/Structure", order = int.MaxValue)]
public class Structure : ScriptableObject
{
    public Transform prefab;
    public float depensive;
    public float attack;
    public float attackSpeed;
    public float durability;
    public int cost;
}
