using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : Weapons
{
    [SerializeField] private ParticleSystem shootParticles;
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            if (WeaponRayCast())
            {
                endPoint = hit.point;
            }
            else
            {
            }
            endPoint = hit.point;
            SetLineRenderer();
            shootParticles.Play();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            lineRenderer.enabled = false;
            shootParticles.Stop();
        }
    }
}
