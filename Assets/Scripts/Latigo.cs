using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latigo : MonoBehaviour
{
    [SerializeField] private Transform puntoBrazo;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform cylinderArm;

    private void Update()
    {
        SetMidiumPoint();
    }

    private void SetMidiumPoint()
    {
        Vector3 midlePoint = playerTransform.position - puntoBrazo.position;
        cylinderArm.position = midlePoint * 0.5f;
        float mag = midlePoint.magnitude * 0.5f;
        cylinderArm.transform.localScale = new Vector3(cylinderArm.transform.localScale.x, mag, cylinderArm.transform.localScale.z);
        
    }
}
