using UnityEngine;

public class CreateEnemyCoommand : ICommand
{
    private Enemies enemyPrefab;
    private Vector3 position;
    private Quaternion rotation;
    private Enemies instance;

    public CreateEnemyCoommand(Enemies enemyPrefab, Vector3 position, Quaternion rotation)
    {
        this.enemyPrefab = enemyPrefab;
        this.position = position;
        this.rotation = rotation;
    }
    public void Execute()
    {
        instance = Object.Instantiate(enemyPrefab, position, rotation);
    }
}