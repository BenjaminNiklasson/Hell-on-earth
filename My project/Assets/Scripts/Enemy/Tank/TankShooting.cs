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

    private Vector2 target;
    void Start()
    {
        ani = transform.GetChild(0).GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        target = new Vector2(player.transform.position.x, player.transform.position.y);
    }
    void Update()
    {
        if (notOnCooldown == true && player != null)
        {
            GameObject aspidProjetile = Instantiate(projectile, transform.position, quaternion.identity);
            Rigidbody2D rb = aspidProjetile.GetComponent<Rigidbody2D>();
            target = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 direcetion = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
            rb.AddForce(direcetion * Speed, ForceMode2D.Impulse);
            notOnCooldown = false;
            Invoke("AfterCooldown", startTimeBtwShoots);
            ani.SetBool("isShooting", true);
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
}
