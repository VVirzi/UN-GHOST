using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Disparito : Enemies
{
    [SerializeField] protected EnemyData enemyData;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementEnemies();
    }
}
