using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFactoryInitializer", menuName = "Factory/EnemyFactoryInitializer")]
public class EnemyFactoryInitializer : ScriptableObject
{
    private EnemyFactory enemyFactory = new();
    [SerializeField] private AvailableEnemyData availableEnemyData;
    public Enemies GetEnemy(string enemyID)
    {
        if (!enemyFactory.Initialized)
        {
            foreach(var enemyData in availableEnemyData.availableEnemies)
            {
                if(enemyID == enemyData.ID)
                {
                    enemyFactory.Initialize(availableEnemyData.availableEnemies);
                    break;
                }
            }
        }
        return enemyFactory.CreateEnemy(enemyID);
    }
}
