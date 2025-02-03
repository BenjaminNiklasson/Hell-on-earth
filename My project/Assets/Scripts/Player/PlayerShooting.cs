using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    [SerializeField] GameObject PlayerBullet;
    [SerializeField] GameObject PlayerGun;
    [SerializeField] int ammoMax = 20;
    [SerializeField] float reloadTime = 5;
    bool isReloading = false;
    int ammo;

    private void Start()
    {
        ammo = ammoMax;
    }

    private void ReloadDone()
    {
        isReloading = false;
    }

    void OnFire()
    {
        if (ammo < 1)
        {
            ammo = ammoMax;
            Invoke("ReloadDone", reloadTime);
            isReloading = true;
        }
        if (isReloading)
        {
            return;
        }
        else
        {
            GameObject bullet = Instantiate(PlayerBullet, PlayerGun.transform.position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
            ammo -= 1;
            Debug.Log($"The pistol has {ammo} ammo!");
        }
    }

    void OnReload()
    {
        ammo = ammoMax;
        Invoke("ReloadDone", reloadTime);
        isReloading = true;
    }
}
