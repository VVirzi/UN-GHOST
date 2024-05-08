using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toxic_Enemy : Enemies
{
    private ParticleCollisionEvent _collisionEvent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementEnemies();
        if(_collisionEvent.colliderComponent != null)
        {
            if (_collisionEvent.colliderComponent.CompareTag("Player"))
            {
                player.GetDamage(10f);
            }
        }
    }

}
