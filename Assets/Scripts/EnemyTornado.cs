using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTornado : Enemies
{
    [SerializeField] private GameObject tornado;
    [SerializeField] protected EnemyData enemyData;
    void Start()
    {

    }

    void Update()
    {
        MovementEnemies();
        if (agent.speed == enemyData.attackSpeed)
        {
            tornado.SetActive(true);
        }
        else
        {
            tornado.SetActive(false);
        }
    }
}
