using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTorreta : MonoBehaviour
{
    [SerializeField] private Transform initialPoint;
    [SerializeField] private Transform finalPoint;
    private Action Torreta;
    private int recipientesConEnemigos = 0;
    void Start()
    {
        SubscribeEvents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SubscribeEvents()
    {
        Torreta += SumarRecipientesConEnemigos;
    }
    private void UnsubscribeEvents()
    {
        Torreta -= SumarRecipientesConEnemigos;
    }
    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void SumarRecipientesConEnemigos()
    {
        recipientesConEnemigos++;
    }
}
