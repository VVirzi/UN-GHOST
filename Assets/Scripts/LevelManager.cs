using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static string lastEnemyKilled;
    public Action RecipientesEvent;
    private int recipientesConEnemigos = 0;
    private int recipientsNeeded = 25;
    [SerializeField] private TextMeshProUGUI textCanvas;
    private void Start()
    {
        SubscribeEvents();
    }
    private void Update()
    {
        RecipientUI();
        if (recipientesConEnemigos == recipientsNeeded)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("VictoryMenu");
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

    private void RecipientUI()
    {
        textCanvas.text = recipientesConEnemigos.ToString() + " / " + recipientsNeeded.ToString();
    }
}
