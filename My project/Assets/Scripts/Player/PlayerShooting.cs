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

    void OnFire()
    {
        if (ammo < 1)
        {
            ammo = ammoMax;
            Invoke("ReloadDone", reloadTime);
            isReloading = true;
            //If our ammo is 0 or less we start reloading, reset our ammo and makes sure we will stop reloading after reloadTime seconds.
        }
        if (isReloading)
        {
            return;
        }
        else
        {
            GameObject bullet = Instantiate(PlayerBullet, PlayerGun.transform.position, transform.rotation);
            //We create a bullet at the guns position and rotation as well as saving the information about that bullet in a gameobject variable.
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            //We grab the rigidbodycomponent from the saved bullet and save it in the variable "rb".
            rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
            ammo -= 1;
            //Adds force to the rb of the bullet and increases it acording to bulletSpeed. Also decreses ammo by one.
            Debug.Log($"The pistol has {ammo} ammo!");
        }
    }

    private void ReloadDone()
    {
        isReloading = false;
    }

    void OnReload()
    {
        ammo = ammoMax;
        Invoke("ReloadDone", reloadTime);
        isReloading = true;
    }
    //Does the same thing as when you lose all your bullets but is conected to a custom input action called Reload that is activated with "R". AKA, you can reload sooner by pressing "R".
}
