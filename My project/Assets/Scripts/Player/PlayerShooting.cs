using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject playerGun;
    [SerializeField] int pistolAmmoMax = 20;
    [SerializeField] int shotgunAmmoMax = 3;
    [SerializeField] int minigunAmmoMax = 100;
    [SerializeField] float reloadTime = 5;
    [SerializeField] int numShotgunShoots;
    [SerializeField] float shotgunSpreadDegrees;
    [SerializeField] float shotgunColdownTime;
    bool isReloading = false;
    bool shotgunColdown = false;
    int ammo;
    bool playerHasShotgun = false;
    bool playerHasMinigun = true;
    bool playerHasPistol = false;

    private void Start()
    {
        ResetAmmo();
    }

    void OnFire()
    {
        if (playerHasShotgun)
        {
            if (ammo < 1)
            {
                ResetAmmo();
                Invoke("ReloadDone", reloadTime);
                isReloading = true;
                //If our ammo is 0 or less we start reloading, reset our ammo and makes sure we will stop reloading after reloadTime seconds.
            }
            if (isReloading)
            {
                return;
            }
            else if (shotgunColdown)
            {
                return;
            }
            else
            {
                Debug.Log(numShotgunShoots);
                for (int i = 0; i < numShotgunShoots; i++)
                {
                    Debug.Log("Pang!");
                    float baseRotationZ = playerGun.transform.rotation.eulerAngles.z;
                    float randomOffset = Random.Range(-shotgunSpreadDegrees, shotgunSpreadDegrees);
                    Quaternion bulletSpawnRotation = Quaternion.Euler(0, 0, baseRotationZ + randomOffset);

                    GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, bulletSpawnRotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(bullet.transform.up * playerBulletSpeed, ForceMode2D.Impulse);
                }
                ammo -= 1;
                Debug.Log($"The shotgun has {ammo} ammo!");
                shotgunColdown = true;
                Invoke("ShotgunColdownDone", shotgunColdownTime);
            }
        }
        else if (playerHasPistol)
        {
            if (ammo < 1)
            {
                ResetAmmo();
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
                GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, transform.rotation);
                //We create a bullet at the guns position and rotation as well as saving the information about that bullet in a gameobject variable.
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                //We grab the rigidbodycomponent from the saved bullet and save it in the variable "rb".
                rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
                ammo -= 1;
                //Adds force to the rb of the bullet and increases it acording to bulletSpeed. Also decreses ammo by one.
                Debug.Log($"The pistol has {ammo} ammo!");
            }
        }
    }

    void OnContinuousFire()
    {
        if (playerHasMinigun)
        {
            if (ammo < 1)
            {
                ResetAmmo();
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
                GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, transform.rotation);
                //We create a bullet at the guns position and rotation as well as saving the information about that bullet in a gameobject variable.
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                //We grab the rigidbodycomponent from the saved bullet and save it in the variable "rb".
                rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
                ammo -= 1;
                //Adds force to the rb of the bullet and increases it acording to bulletSpeed. Also decreses ammo by one.
                Debug.Log($"The minigun has {ammo} ammo!");
            }
        }
    }

    private void ReloadDone()
    {
        isReloading = false;
    }

    private void ShotgunColdownDone()
    {
        shotgunColdown = false;
    }

    private void ResetAmmo()
    {
        if (playerHasPistol)
        {
            ammo = pistolAmmoMax;
        }
        else if (playerHasShotgun)
        {
            ammo = shotgunAmmoMax;
        }
        else if (playerHasMinigun)
        {
            ammo = minigunAmmoMax;
        }
    }

    void OnReload()
    {
        ResetAmmo();
        Invoke("ReloadDone", reloadTime);
        isReloading = true;
    }
    //Does the same thing as when you lose all your bullets but is conected to a custom input action called Reload that is activated with "R". AKA, you can reload sooner by pressing "R".
}
