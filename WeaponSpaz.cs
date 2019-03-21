using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpaz : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private SoundManager sm;
    private Animator anim;

    void Start()
    {
        sm = SoundManager.Instance;
        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        anim.SetTrigger("Shot");
        sm.PlayShootingSound();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
