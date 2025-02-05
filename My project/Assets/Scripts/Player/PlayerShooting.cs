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
    [SerializeField] float pistolReloadTime = 1.5f;
    [SerializeField] float shotgunReloadTime = 2.5f;
    [SerializeField] float minigunReloadTime = 5;
    [SerializeField] int numShotgunShoots;
    [SerializeField] float shotgunSpreadDegrees;
    [SerializeField] float shotgunColdownTime;
    [SerializeField] float minMinigunColdownTime;
    [SerializeField] float maxMinigunColdownTime;
    [SerializeField] float coldownRate;
    bool isReloading = false;
    bool gunColdown = false;
    int ammo;
    bool playerHasShotgun = false;
    bool playerHasMinigun = true;
    bool playerHasPistol = false;
    bool currentlyShooting = false;
    bool currentlyInvokingWindup = false;
    float currentMinigunColdownTime;

    private void Start()
    {
        ResetAmmo();
        currentMinigunColdownTime = maxMinigunColdownTime;
    }

    private void Update()
    {
        if (currentlyShooting)
        {
            if (playerHasMinigun)
            {
                if (ammo < 1)
                {
                    ResetAmmo();
                    Invoke("ReloadDone", minigunReloadTime);
                    isReloading = true;
                    //If our ammo is 0 or less we start reloading, reset our ammo and makes sure we will stop reloading after reloadTime seconds.
                }
                if (isReloading)
                {
                    return;
                }
                else if (gunColdown)
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
                    Debug.Log($"The Minigun has {ammo} ammo!");
                    gunColdown = true;
                    Invoke("gunColdownDone", currentMinigunColdownTime);
                }
                if (currentMinigunColdownTime >= minMinigunColdownTime)
                {
                    Debug.Log("currentMinigunColdownTime >= minMinigunColdownTime");
                    if (currentlyInvokingWindup == false)
                    {
                        Invoke("DecreaseGunColdown", coldownRate);
                        currentlyInvokingWindup = true;
                        Debug.Log("currentlyInvokingWindup == false");
                    }
                }
            }
        }
        else
        {
            if (currentMinigunColdownTime < maxMinigunColdownTime)
            {
                Debug.Log("currentMinigunColdownTime < maxMinigunColdownTime");
                if (currentlyInvokingWindup == false)
                {
                    Invoke("IncreaseGunColdown", coldownRate);
                    currentlyInvokingWindup = true;
                    Debug.Log("currentlyInvokingWindup == false");
                }
            }
        }
    }

    void IncreaseGunColdown()
    {
        currentMinigunColdownTime = currentMinigunColdownTime * 1.25f;
        currentlyInvokingWindup = false;
        Debug.Log("IncreaseGunColdown");
    }

    void DecreaseGunColdown()
    {
        currentMinigunColdownTime = currentMinigunColdownTime * 0.8f;
        currentlyInvokingWindup = false;
        Debug.Log("DecreaseGunColdown");
    }

    void OnFire()
    {
        if (playerHasShotgun)
        {
            if (ammo < 1)
            {
                ResetAmmo();
                Invoke("ReloadDone", shotgunReloadTime);
                isReloading = true;
                //If our ammo is 0 or less we start reloading, reset our ammo and makes sure we will stop reloading after reloadTime seconds.
            }
            if (isReloading)
            {
                return;
            }
            else if (gunColdown)
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
                gunColdown = true;
                Invoke("gunColdownDone", shotgunColdownTime);
            }
        }
        else if (playerHasPistol)
        {
            if (ammo < 1)
            {
                ResetAmmo();
                Invoke("ReloadDone", pistolReloadTime);
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
        currentlyShooting =! currentlyShooting;
    }

    private void ReloadDone()
    {
        isReloading = false;
    }

    private void gunColdownDone()
    {
        gunColdown = false;
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
        if (playerHasPistol)
        {
            Invoke("ReloadDone", pistolReloadTime);
        }
        else if (playerHasShotgun)
        {
            Invoke("ReloadDone", shotgunReloadTime);
        }
        else if (playerHasMinigun)
        {
            Invoke("ReloadDone", minigunReloadTime);
        }
        isReloading = true;
    }
    //Does the same thing as when you lose all your bullets but is conected to a custom input action called Reload that is activated with "R". AKA, you can reload sooner by pressing "R".
}
