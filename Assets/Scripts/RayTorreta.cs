using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayTorreta : MonoBehaviour
{
    [SerializeField] private Transform initialPoint;
    [SerializeField] private Transform finalPoint;
    public Action StartRayEvent;
    private LineRenderer rayoLaser;
    private bool startRayLaser = false;
    private float acumulador=0;

    void Start()
    {
        rayoLaser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startRayLaser)
        {
            acumulador += Time.deltaTime;
            rayoLaser.SetPosition(0, initialPoint.position);
            rayoLaser.SetPosition(1, finalPoint.position);
            if (acumulador > 10f)
            {
                SceneManager.LoadScene("VictoryMenu");
            }
        }
    }

    private void SubscribeEvents()
    {
        StartRayEvent += SetRayLaser;
    }
    private void UnsubscribeEvents()
    {
        StartRayEvent -= SetRayLaser;
    }
    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void SetRayLaser()
    {
        startRayLaser = true;
    }
}
