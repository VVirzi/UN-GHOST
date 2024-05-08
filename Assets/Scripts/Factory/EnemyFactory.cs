using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : AbstractFactory<Enemies>
{
    public bool Initialized {  get; private set; }
    private EnemyData[] enemyDataList;
    public override Enemies CreateEnemy(string enemyID)
    {
        foreach(var enemyData in enemyDataList)
        {
            if(enemyData.ID == enemyID)
            {
                return enemyData.EnemiesPrefab;
            }
        }
        return null;
    }

    public void Initialize(EnemyData[] enemyDataList)
    {
        this.enemyDataList = enemyDataList;
        Initialized = true;
    }
}
