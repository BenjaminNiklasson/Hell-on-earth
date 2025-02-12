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
    public bool isShooting = false;

    //variables for shooting
    [SerializeField] GameObject shootLaserLeft;
    [SerializeField] GameObject shootLaserRight;
    [SerializeField] GameObject targetingLine;
    [SerializeField] float reloadTime = 1.5f;
    RailerLooking rl;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        rl = transform.GetChild(0).GetComponent<RailerLooking>();
    }
    void Update()
    {
        //When on the ground and too close to player it will move away
        if (player != null && isGrounded == true)
        {
            if (tooCloseToPlayer == true && isShooting == false)
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;
                rb.MovePosition(rb.position - direction * eSpeed * Time.fixedDeltaTime);
            }
            else if (isShooting == false && tooCloseToPlayer == false)
            {
                isShooting = true;
                RailerTargeting();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AspidAway"))
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
        if (collision.gameObject.CompareTag("AspidAway"))
        {
            tooCloseToPlayer = false;
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
    private void RailerTargeting()
    {
        GameObject targeting = Instantiate(targetingLine, transform.GetChild(0).GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
        targeting.transform.SetParent(transform.GetChild(0).GetChild(0));
        Debug.Log("Targeting...");
        Invoke("RailerShooting", reloadTime);
    }
    GameObject laser;
    private void RailerShooting()
    {
        if (transform.localScale.x < 0)
        {
            laser = Instantiate(shootLaserRight, transform.GetChild(0).GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
        }
        else if (transform.localScale.x > 0)
        {
            laser = Instantiate(shootLaserLeft, transform.GetChild(0).GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
        }
        laser.transform.SetParent(transform.GetChild(0).GetChild(0));
        rl.stopAim = true;
        Debug.Log("FIRE!");
        Invoke("Falsify", 4f);
    }
    private void Falsify()
    {
        isShooting = false;
        rl.stopAim = false;
        Debug.Log("Falsifying");
    }
}