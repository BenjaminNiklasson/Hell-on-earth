using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AspidShooting : MonoBehaviour
{
    private float timeBtwShoots = 2;
    [SerializeField]public float  startTimeBtwShoots;

    public GameObject projectile;
    GameObject player;
   [SerializeField] public float Speed;

    
    private Vector2 target;


    private void Start()
    {
        timeBtwShoots = startTimeBtwShoots;
        player = GameObject.FindWithTag("player");
        target = new Vector2(player.transform.position.x, player.transform.position.y);
    }


    private void Update()
    {
        if(timeBtwShoots >= 0)
        {
            GameObject aspidProjetile = Instantiate(projectile, transform.position,quaternion.identity);
            Rigidbody2D rb = aspidProjetile.GetComponent<Rigidbody2D>();
            aspidProjetile.transform.position = Vector2.MoveTowards(aspidProjetile.transform.position, target, Speed * Time.deltaTime);
            timeBtwShoots = startTimeBtwShoots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
