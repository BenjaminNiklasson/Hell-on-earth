using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;


public class TankShooting : MonoBehaviour
{
    [SerializeField] public float startTimeBtwShoots;
    bool notOnCooldown = true;
    public GameObject projectile;
    GameObject player;
    [SerializeField] public float Speed;
    Animator ani;
    Rigidbody2D rb;
    GameObject TankProjectile;

    Vector2 target;
    void Start()
    {
        ani = transform.GetChild(0).GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (notOnCooldown == true && player != null)
        {
            ani.SetBool("isShooting", true);
            TankProjectile = Instantiate(projectile, transform.position, quaternion.identity);
            rb = TankProjectile.GetComponent<Rigidbody2D>();
            target = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 direcetion = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
            rb.AddForce(new Vector2(direcetion.x + Speed * Time.deltaTime, direcetion.y + Speed * Time.deltaTime), ForceMode2D.Impulse);
            notOnCooldown = false;
            Invoke("AfterCooldown", startTimeBtwShoots);
            ani.SetBool("IsShooting", true);
            Invoke("AfterAnimation", 2);
        }
        else
        {
            ani.SetBool("isShooting", false);
        }
    }
    void AfterCooldown()
    {
        notOnCooldown = true;
    }
    void AfterAnimation()
    {
        ani.SetBool("IsShooting", false);
    }
}
