using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Object/new Enemy Data", order = int.MaxValue)]
public class EnemyData : ScriptableObject
{
    public string name;
    public int health;
    public float speed;
}
