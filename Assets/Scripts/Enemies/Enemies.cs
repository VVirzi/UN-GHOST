using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemies : MonoBehaviour, IEnemy
{
    protected float life;
    [SerializeField] protected PlayerController player;
    [SerializeField] protected Transform[] interestPoints;

    protected Vector3 moveToThis;
    void Start()
    {
    }


    void Update()
    {

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
