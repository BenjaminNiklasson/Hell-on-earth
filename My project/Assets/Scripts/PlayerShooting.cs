using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject PlayerGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnFire()
    {
        GameObject bullet = Instantiate(Bullet, PlayerGun.transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
    }
}
