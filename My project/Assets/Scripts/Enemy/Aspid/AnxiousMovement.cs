using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxiousMovement : MonoBehaviour
{
    [SerializeField] float eSpeed = 3f;
    Rigidbody2D rb;
    GameObject getAway;
    bool tooCloseToPlayer = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        getAway = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (getAway != null)
        {
            if (tooCloseToPlayer == false)
            {
                Vector2 direction = (getAway.transform.position - transform.position).normalized;
                rb.MovePosition(rb.position + direction * eSpeed * Time.fixedDeltaTime);
            }
            else
            {
                Vector2 direction = (getAway.transform.position - transform.position).normalized;
                Vector2 movement = rb.position - direction * eSpeed * Time.fixedDeltaTime;
                rb.MovePosition(movement);
                transform.GetChild(0).GetComponent<Rigidbody2D>().MovePosition(movement);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AspidAway"))
        {
            tooCloseToPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AspidAway"))
        {
            tooCloseToPlayer = false;
        }
    }
}
