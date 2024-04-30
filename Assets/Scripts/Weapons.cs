using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] protected Transform weaponPoint;
    [SerializeField] protected Camera weaponSight;
    protected Vector3 endPoint;
    protected LineRenderer lineRenderer;
    protected RaycastHit hit;

    protected void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    protected bool WeaponRayCast()
    {
        if(Physics.Raycast(weaponSight.transform.position, weaponSight.transform.forward, out hit, 7f))
        {
            if(hit.transform.tag == "Enemigo")
            {
                return true;
            }
        }
        return false;
    }

    protected void SetLineRenderer()
    {
        lineRenderer.SetPosition(0, weaponPoint.transform.position);
        lineRenderer.SetPosition(1, endPoint);
        lineRenderer.enabled = true;
    }
}
