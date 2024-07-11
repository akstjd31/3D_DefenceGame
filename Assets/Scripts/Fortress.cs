using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fortress", menuName = "Scriptable Object/Fortress", order = int.MaxValue)]
public class Fortress : ScriptableObject
{
    public Transform prefab;
    public float depensive;
    public float attack;
    public float attackSpeed;
    public float durability;
    public int cost;
}
