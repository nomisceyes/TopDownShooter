using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    readonly private float _scatter = 30f;

    private void Start()
    {
        TimeOfReload = 1f;
    }

    protected override void Shoot()
    {
        Vector3 Angle = FirePoint.eulerAngles;

        if (Input.GetMouseButtonDown(0) && _isCharged)
        {
            Angle.z -= _scatter;

           AudioSource.Play();

            for (int i = 0; i < 3; i++)
            {
                Instantiate(_bullet, FirePoint.position, Quaternion.Euler(Angle));
                Angle.z += _scatter;
                StartCoroutine(Reload());
            }
        }
    }
}