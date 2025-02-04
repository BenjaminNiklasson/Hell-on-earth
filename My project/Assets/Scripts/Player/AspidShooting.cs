using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AspidShooting : MonoBehaviour
{
    private float timeBtwShoots;
    [SerializeField]public float  startTimeBtwShoots;

    public GameObject projectile;
    GameObject player;


    private void Start()
    {
        timeBtwShoots = startTimeBtwShoots;
        player = GameObject.FindWithTag("player");

    }


    private void Update()
    {
        if(timeBtwShoots >= 0)
        {
            Instantiate(projectile, transform.position,quaternion.identity);
            timeBtwShoots = startTimeBtwShoots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }

}
