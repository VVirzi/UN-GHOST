using UnityEngine;
//using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyCommandGenerator enemyCommandGenerator;
    private string enemyType;
    private float timeAcumulation;
    enum EnemyType
    {
        Disparito,
        Tornado,
        Toxic
    }
    
    [SerializeField] private AvailableEnemyData EnemyID;
    [SerializeField] private WaypointsProvider WaypointsProvider;
    private void Awake()
    {
        enemyType = GetRandonEnemyID();
    }

    private void Update()
    {
        timeAcumulation += Time.deltaTime;
        if (timeAcumulation > 15f)
        {
            enemyType = GetRandonEnemyID();
            GenerateEnemy(enemyType);
            timeAcumulation = 0;
        }
    }

    private void GenerateEnemy(string enemyType)
    {
        if (!enemyCommandGenerator.TryGenerateEnemyCreationCommand(enemyType,
                transform.position,transform.rotation, WaypointsProvider.Waypoints, out var enemyCommand))
        {
            return;
        }
            
        EventQueue.Instance.EnqueueCommand(enemyCommand);
    }

    private string GetRandonEnemyID()
    {
        var indice = Random.Range(0, 3);
        return EnemyID.availableEnemies[indice].ID;
    }
    
}

