using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    //When we add force to our bullet we times the added force with this number.
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject playerGun;
    [SerializeField] int pistolAmmoMax = 20;
    [SerializeField] int shotgunAmmoMax = 3;
    [SerializeField] int minigunAmmoMax = 100;
    // Specified gun will be able to fire this many times before invoking a coldown.
    [SerializeField] float pistolReloadTime = 1.5f;
    [SerializeField] float shotgunReloadTime = 2.5f;
    [SerializeField] float minigunReloadTime = 5;
    // How long coldown specified gun has to wait while reloading.
    [SerializeField] int numShotgunShoots;
    // How many bullets that are fired from the shotgun;
    [SerializeField] float shotgunSpreadDegrees;
    [SerializeField] float minigunSpreadDegrees;
    // How many degrees + and - from the shotguns or miniguns current angle the shots are goining get degrees between, aka firearc.
    [SerializeField] float shotgunColdownTime;
    // A shorter coldown between shots, so that you can't spam all your shots at once, note that the pistol has no such cap.
    [SerializeField] float minMinigunColdownTime;
    [SerializeField] float maxMinigunColdownTime;
    // The minigun has a windup. Therefor the actuall coldown between shots will start at the maxcoldown but lessen as you shoot but not lower that mincoldown. 
    // While idle it will go back up to max again but not further.
    [SerializeField] float coldownChangeRate;
    // How often the coldowntime will decrees.
    bool isReloading = false;
    // You can only shoot when this is false and it turns true for a while when you lose all ammo.
    bool gunColdown = false;
    // You can only shoot when this is false and it turns true for a while when you shoot with the minigun or shotgun.
    int ammo;
    bool playerHasShotgun = false;
    bool playerHasMinigun = false;
    bool playerHasPistol = true;
    // Desides witch type of shooting should be active.
    bool playerHasShotgunEquipped = false;
    bool playerHasMinigunEquipped = false;
    bool playerHasPistolEquipped = true;
    // Desides witch type of shooting should be active.
    bool currentlyShooting = false;
    // Is active while player is pushing down the fire button;
    bool currentlyInvokingWindup = false;
    // I have a invoke in update, it only ivokes when this bool is false. Otherwise it would start multiple ivokes at once.
    float currentMinigunColdownTime;
    // The actuall coldowntime between shots for minigun. 

    private void Start()
    {
        ResetAmmo();
        currentMinigunColdownTime = maxMinigunColdownTime;
    }

    private void Update()
    {
        if (currentlyShooting && !isReloading)
        {
            //Checks if we are currently shooting and not reloading. These are in the same so that you cna't negate the windown while reloading by just continuing to press fire.
            if (playerHasMinigunEquipped && playerHasMinigun)
            {
                // Makes sure we have minigun and the minigun equipped.
                if (ammo < 1)
                {
                    ResetAmmo();
                    Invoke("ReloadDone", minigunReloadTime);
                    isReloading = true;
                    //If our ammo is 0 or less we start reloading, reset our ammo and makes sure we will stop reloading after reloadTime seconds.
                }
                if (gunColdown)
                {
                    return;
                    //Makes it so that you can't shoot while on coldown.
                }
                else
                {
                    float baseRotationZ = playerGun.transform.rotation.eulerAngles.z;
                    float randomOffset = Random.Range(-minigunSpreadDegrees, minigunSpreadDegrees);
                    Quaternion bulletSpawnRotation = Quaternion.Euler(0, 0, baseRotationZ + randomOffset);
                    
                    GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, bulletSpawnRotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
                    ammo -= 1;
                    gunColdown = true;
                    Invoke("gunColdownDone", currentMinigunColdownTime);

                    // Spawns one bullet per itteration of the forloop.
                    // First we get the rotation of the wepon, then randomly alters it by a number between the positive and negative version of the firearc.
                    // Lastly we instantiate the bullet with the randomly given rotation and gives it force in that direction.
                    // Decreases ammo and puts the gun on coldown.
                }
                if (isReloading)
                {
                    return;
                }
                else if (currentMinigunColdownTime >= minMinigunColdownTime)
                {
                    if (currentlyInvokingWindup == false)
                    {
                        Invoke("DecreaseGunColdown", coldownChangeRate);
                        currentlyInvokingWindup = true;
                        // When we arren't reloading and we arent at our minimum coldowntime we increas our coldowntime and make sure we can't invoke the method that decreases the coldown time until coldownchangerate seconds have passed.
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
                    Invoke("IncreaseGunColdown", coldownChangeRate);
                    currentlyInvokingWindup = true;
                    Debug.Log("currentlyInvokingWindup == false");
                    // Increses the coldowntime instead. Always does this except when you are fireing.
                }
            }
        }
    }

    void OnFire()
    {
        if (playerHasShotgunEquipped && playerHasShotgun)
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
                //Makes it so that you can't shoot while reloading.
            }
            else if (gunColdown)
            {
                return;
                //Makes it so that you can't shoot while on coldown.
            }
            else
            {
                for (int i = 0; i < numShotgunShoots; i++)
                {
                    Debug.Log("Pang!");
                    float baseRotationZ = playerGun.transform.rotation.eulerAngles.z;
                    float randomOffset = Random.Range(-shotgunSpreadDegrees, shotgunSpreadDegrees);
                    Quaternion bulletSpawnRotation = Quaternion.Euler(0, 0, baseRotationZ + randomOffset);

                    GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, bulletSpawnRotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(bullet.transform.up * playerBulletSpeed, ForceMode2D.Impulse);
                    // Spawns one bullet per itteration of the forloop.
                    // First we get the rotation of the wepon, then randomly alters it by a number between the positive and negative version of the firearc.
                    // Lastly we instantiate the bullet with the randomly given rotation and gives it force in that direction.
                }
                ammo -= 1;
                gunColdown = true;
                Invoke("gunColdownDone", shotgunColdownTime);
                // Decreases ammo and puts the gun on coldown.
            }
        }
        else if (playerHasPistolEquipped && playerHasPistol)
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
                GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, playerGun.transform.rotation);
                //We create a bullet at the guns position and rotation as well as saving the information about that bullet in a gameobject variable.
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                //We grab the rigidbodycomponent from the saved bullet and save it in the variable "rb".
                rb.AddForce(playerGun.transform.up * playerBulletSpeed, ForceMode2D.Impulse);
                ammo--;
                //Adds force to the rb of the bullet and increases it acording to bulletSpeed. Also decreses ammo by one.
                Debug.Log($"The pistol has {ammo} ammo!");
            }
        }
    }

    void OnContinuousFire()
    {
        currentlyShooting =! currentlyShooting;
        // It runs when the player clicks and stops so firering will be active while the player is pushing down specefied button.
    }

    void IncreaseGunColdown()
    {
        currentMinigunColdownTime = currentMinigunColdownTime * 1.25f;
        currentlyInvokingWindup = false;
        // Lets other code call upon the method once again as well as incresing the miniguncoldowntime.
    }

    void DecreaseGunColdown()
    {
        currentMinigunColdownTime = currentMinigunColdownTime * 0.8f;
        currentlyInvokingWindup = false;
        // Same but decreases. I have the numbers 1.25 and 0.8 because 0.8 *1.25 = 0.
    }

    private void ReloadDone()
    {
        isReloading = false;
        //Makes you able to shoot again.
    }

    private void gunColdownDone()
    {
        gunColdown = false;
        // Makes you able to shoot again.
    }

    private void ResetAmmo()
    {
        if (playerHasPistol && playerHasPistolEquipped)
        {
            ammo = pistolAmmoMax;
        }
        else if (playerHasShotgun && playerHasShotgunEquipped)
        {
            ammo = shotgunAmmoMax;
        }
        else if (playerHasMinigun && playerHasMinigunEquipped)
        {
            ammo = minigunAmmoMax;
        }
        // Reloads ammo and makes sure it is as much ammo as the current gun your using.
    }

    void OnReload()
    {
        ResetAmmo();
        if (playerHasPistolEquipped)
        {
            Invoke("ReloadDone", pistolReloadTime);
        }
        else if (playerHasShotgunEquipped)
        {
            Invoke("ReloadDone", shotgunReloadTime);
        }
        else if (playerHasMinigunEquipped)
        {
            Invoke("ReloadDone", minigunReloadTime);
        }
        isReloading = true;
    }
    //Does the same thing as when you lose all your bullets but is conected to a custom input action called Reload that is activated with "R". AKA, you can reload sooner by pressing "R".

    void OnSwitchToMinigun()
    {
        if (playerHasMinigun)
        {
            playerHasMinigunEquipped = true;
            playerHasPistolEquipped = false;
            playerHasShotgunEquipped = false;
            OnReload();
        }
    }
    void OnSwitchToShotgun()
    {
        if (playerHasShotgun)
        {
            playerHasMinigunEquipped = false;
            playerHasPistolEquipped = false;
            playerHasShotgunEquipped = true;
            OnReload();
        }
    }
    void OnSwitchToPistol()
    {
        playerHasMinigunEquipped = false;
        playerHasPistolEquipped = true;
        playerHasShotgunEquipped = false;
        OnReload();
    }
    // You can switch your current wepon with the buttons 1,2 and 3 but you have to reload when doing so.

    public void ActivateShotgun()
    {
        playerHasShotgun = true;
        OnSwitchToShotgun();
    }
    // It activates when the player collides with the shotgunpickup.

    public void ActivateMinigun()
    {
        playerHasShotgun = true;
        OnSwitchToMinigun();
    }
    // It activates when the player collides with the minigunpickup.
}
