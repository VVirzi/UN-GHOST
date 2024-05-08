using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toxic_Enemy : Enemies, IDamagable
{
    [SerializeField] protected EnemyData enemyData;
    void Start()
    {
        life = enemyData.life;
        moveToThis = GetRandomVectorFromList();
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardPlayer();
        if (ApplyGravityWhenNeeded())
        {
            transform.position -= new Vector3(0, 5.5f, 0) * Time.deltaTime;
        }
        MovementEnemies();
        
    }
    protected void MovementEnemies()
    {
        if (player != null)
        {
            agent.speed = enemyData.attackSpeed;
            moveToThis = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
        }
        else
        {
            agent.speed = enemyData.normalSpeed;
            var magnitud = GetVectorEnemyToPoint(moveToThis).magnitude;
            if (magnitud < 1f)
            {
                moveToThis = GetRandomVectorFromList();
            }
        }
        agent.destination = moveToThis;
    }
    public void GetDamage(float damage)
    {
        life -= damage;
        if (life < 0f)
        {
            LevelManager.lastEnemyKilled = enemyData.ID;
            Destroy(this.gameObject);
        }
    }
}
