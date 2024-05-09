using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static string lastEnemyKilled;
    [SerializeField] private Recipiente[] recipientesInGame;
    public Action RecipientesEvent;
    private int recipientesConEnemigos = 0;
    [SerializeField] private RayTorreta torreta;

    private void Start()
    {
        SubscribeEvents();
    }
    private void Update()
    {
        if(recipientesConEnemigos == recipientesInGame.Length)
        {
            torreta.StartRayEvent?.Invoke();
        }
    }

    private void SubscribeEvents()
    {
        RecipientesEvent += SumarRecipientesConEnemigos;
    }
    private void UnsubscribeEvents()
    {
        RecipientesEvent -= SumarRecipientesConEnemigos;
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
