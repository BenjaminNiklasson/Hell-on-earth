using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AspidShooting : MonoBehaviour
{
    [SerializeField]public float  startTimeBtwShoots;
    bool notOnCooldown = true;
    public GameObject projectile;
    GameObject player;
    [SerializeField] public float Speed;
    private Vector2 target;
    public bool isShooting = false;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        target = new Vector2(player.transform.position.x, player.transform.position.y);
    }


    private void Update()
    {
        if(notOnCooldown == true && player != null)
        {
            isShooting = true;
            notOnCooldown = false;
            Invoke("Falsify", 0.25f);
            Invoke("Shoot", 0);
        }
    }

    void AfterCooldown()
    {
        notOnCooldown = true;
        isShooting = false;
    }
    void Shoot()
    {
        GameObject aspidProjetile = Instantiate(projectile, transform.position, quaternion.identity);
        Rigidbody2D rb = aspidProjetile.GetComponent<Rigidbody2D>();
        target = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 direcetion = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        rb.MovePosition(rb.position + direcetion * Speed * Time.fixedDeltaTime);
        Invoke("AfterCooldown", startTimeBtwShoots);
    }
    void Falsify()
    {
        isShooting = false;
    }
}
