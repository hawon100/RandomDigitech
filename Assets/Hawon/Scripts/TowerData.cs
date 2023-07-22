using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Data", menuName = "Scriptable Object/new Tower Data", order = int.MaxValue)]
public class TowerData : ScriptableObject
{
    public string name;
    public float atkSpeed;
    public GameObject unit;
    public TowerData nextTowerData;
}
