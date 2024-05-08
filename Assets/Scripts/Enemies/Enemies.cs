using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemies : MonoBehaviour, IEnemy, IDamagable
{
    protected float life = 100;
    [SerializeField] protected PlayerController player;
    [SerializeField] protected NavMeshAgent agent;
    protected float attackSpeed = 3f;
    protected float normalSpeed = 1.5f;
    [SerializeField] protected Transform[] interestPoints;
    protected Vector3 moveToThis;
    void Start()
    {
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
    }

    protected void RotateTowardPlayer()
    {
        Vector3 playerPosition = player.gameObject.transform.position;
        Quaternion lookAt = Quaternion.LookRotation(playerPosition - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAt, 1.5f);
    }
    protected bool ApplyGravityWhenNeeded()
    {
        if (transform.position.y > 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void MovementEnemies()
    {
        if (player != null)
        {
            agent.speed = attackSpeed;
            moveToThis = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
        }
        else
        {
            agent.speed = normalSpeed;
            var magnitud = GetVectorEnemyToPoint(moveToThis).magnitude;
            if (magnitud < 1f)
            {
                moveToThis = GetRandomVectorFromList();
            }
        }
        agent.destination = moveToThis;
    }

    protected Vector3 GetVectorEnemyToPoint(Vector3 objetivo)
    {
        Vector3 directionTo = objetivo - transform.position;
        directionTo.y = 0f;
        return directionTo;
    }

    protected Vector3 GetRandomVectorFromList()
    {
        var indice = Random.Range(0, 11);
        return interestPoints[indice].transform.position;
    }

    public void SetWaypoints(Transform[] waypoints)
    {
        interestPoints = waypoints;
    }

    public void SetPlayer(PlayerController playerController)
    {
        player = playerController;
    }

    public void GetDamage(float damage)
    {
        life -= damage;
        if(life < 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
