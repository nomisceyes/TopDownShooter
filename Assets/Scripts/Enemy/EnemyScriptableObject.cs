using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemyScriptableObject : ScriptableObject
{
    public string Name;
    public float Speed;
    public int Health;
    public int Damage;
    public int AttackRange;  
}
