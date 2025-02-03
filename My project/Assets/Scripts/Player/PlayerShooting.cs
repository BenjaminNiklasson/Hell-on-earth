using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    [SerializeField] GameObject PlayerBullet;
    [SerializeField] GameObject PlayerGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnFire()
    {
        GameObject bullet = Instantiate(PlayerBullet, PlayerGun.transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
    }
}
