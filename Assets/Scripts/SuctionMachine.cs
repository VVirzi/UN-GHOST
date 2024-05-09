using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuctionMachine : Weapons
{
    [SerializeField] private float fuerzaDeAbsorcion;
    private Vector3 directionForce;
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (WeaponRayCast()!=null)
            {
                endPoint = hit.point;
                directionForce = DirectionCalculate(weaponPoint.transform.position, endPoint);
                directionForce = directionForce * fuerzaDeAbsorcion * Time.deltaTime;
                hit.transform.position += directionForce;
                ChangeEnemyScale(hit);
            }
            else
            {
                directionForce = Vector3.zero;
            }
            endPoint = hit.point;
            SetLineRenderer();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            lineRenderer.enabled = false;
        }

    }

    private Vector3 DirectionCalculate(Vector3 vectorInicial, Vector3 vectorFinal)
    {
        Vector3 resultado = vectorFinal - vectorInicial;
        return resultado.normalized;
    }

    private void ChangeEnemyScale(RaycastHit hit)
    {
        if (hit.transform.localScale.x < 1 || hit.transform.localScale.y < 1 || hit.transform.localScale.z < 1)
        {
            return;
        }
        else
        {
            hit.transform.localScale -= Vector3.one * 2f*Time.deltaTime;
        }
    }

}
