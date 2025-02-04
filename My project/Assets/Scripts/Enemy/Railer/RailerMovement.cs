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
    bool isShooting = false;
    bool stopMoving = false;

    //variables for shooting
    [SerializeField] GameObject shootLaser;
    [SerializeField] GameObject railGun;
    [SerializeField] GameObject targetingLine;
    [SerializeField] float reloadTime = 1.5f;
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
                isShooting = true;
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
        }
    }
    private void RailerTargeting(Vector3 playerPos)
    {
        GameObject targeting = Instantiate(targetingLine, railGun.transform.position, railGun.transform.rotation);
        Debug.Log("Targeting...");
        Invoke("RailerShooting", reloadTime);
    }
    private void RailerShooting()
    {
        GameObject laser = Instantiate(shootLaser, railGun.transform.position, railGun.transform.rotation);
        Debug.Log("FIRE!");
        Invoke("Falsify", 4f);
    }
    private void Falsify()
    {
        stopMoving = false;
        isShooting = false;
    }

    public bool IsMoving()
    {
        return stopMoving;
    }
}