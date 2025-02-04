using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RailerMovement : MonoBehaviour
{
    //variables for movement
    [SerializeField] float eSpeed = 3f;
    Rigidbody2D rb;
    GameObject player;
    bool tooCloseToPlayer = false;
    bool isGrounded = false;
    bool isShooting = true;
    bool stopMoving = false;

    //variables for shooting

    [SerializeField] GameObject shootLaser;
    [SerializeField] GameObject railGun;
    [SerializeField] GameObject targetingLine;
    [SerializeField] float reloadTime = 3f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //When on the ground and too close to player it will move away
        if (player != null && isGrounded == true && stopMoving == false)
        {
            if (tooCloseToPlayer == true)
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;
                rb.MovePosition(rb.position - direction * eSpeed * Time.fixedDeltaTime);
            }
            else if (isShooting == false && tooCloseToPlayer == false)
            {
                stopMoving = true;
                RailerTargeting(player.transform.position);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tooCloseToPlayer = true;
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            Debug.Log("on the ground");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tooCloseToPlayer = false;
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
            Debug.Log("off the ground");
        }
    }
    private void RailerTargeting(Vector3 playerPos)
    {
        GameObject targeting = Instantiate(targetingLine, railGun.transform.position, transform.rotation);
        Invoke("RailerShooting", reloadTime);
    }
    private void RailerShooting(Vector3 playerPos)
    {
        GameObject laser = Instantiate(shootLaser, railGun.transform.position, transform.rotation);
        stopMoving = false;
    }
}
