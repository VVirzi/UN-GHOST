using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AvailableEnemyData", menuName = "Enemy/AvailableEnemyData")]
public class AvailableEnemyData : ScriptableObject
{
    [SerializeField] public EnemyData[] availableEnemies;
}
