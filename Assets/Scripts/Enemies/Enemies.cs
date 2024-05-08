using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemies : MonoBehaviour, IEnemy
{
    protected float life;
    [SerializeField] protected PlayerController player;
    [SerializeField] protected NavMeshAgent agent;
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
}
