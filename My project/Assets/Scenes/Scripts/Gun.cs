using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public SoundsEffector soundsEffector;

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButtonDown("Fire1"))
        {
            soundsEffector.PlayShootSound();
            Shoot();
        }
    }

    void Shoot() => Instantiate(bullet, firePoint.position, firePoint.rotation);
}
