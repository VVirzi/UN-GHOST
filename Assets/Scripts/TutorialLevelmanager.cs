using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLevelmanager : MonoBehaviour
{
    public Action FinishLevel;
    private bool endLevel = false;
    private float counter;
    [SerializeField] private GameObject robot;
    void Start()
    {
        SubscribeEvents();
    }

    void Update()
    {
        if (endLevel)
        {
            counter += Time.deltaTime;
            if (counter > 5f) 
            {
                SceneManager.LoadScene("PortalLevel");
            }
        }
    }

    private void SubscribeEvents()
    {
        FinishLevel += StartEndTemporizer;
    }
    private void UnsubscribeEvents()
    {
        FinishLevel -= StartEndTemporizer;
    }

    private void StartEndTemporizer()
    {
        Destroy(robot);
        endLevel = true;
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }
}
