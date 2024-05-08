using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTornado : Enemies
{
    [SerializeField] private GameObject tornado;
    void Start()
    {

    }

    void Update()
    {
        MovementEnemies();
        if (agent.speed == attackSpeed)
        {
            tornado.SetActive(true);
        }
        else
        {
            tornado.SetActive(false);
        }
    }
}
