using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChequeoDeColision : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Estoy tocando");
        }
    }
}
