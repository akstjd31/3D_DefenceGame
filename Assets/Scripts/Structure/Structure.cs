using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Structure", menuName = "Scriptable Object/Structure", order = int.MaxValue)]

public class Structure : ScriptableObject
{
    public Transform prefab;
    public string name;
    public Texture texture;
    public float depensive;
    public float attack;
    public float attackSpeed;
    public float durability;
    public int cost;    
    public RATING_TABLE ratingTable;
}
