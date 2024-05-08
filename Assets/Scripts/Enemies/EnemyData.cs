using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public Enemies EnemiesPrefab { get; private set; }
    [field: SerializeField] public string ID { get; private set; }

    [field: SerializeField] public float life { get; private set; }
}
