using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxiousMovement : MonoBehaviour
{
    [SerializeField] float eSpeed = 3f;
    Rigidbody2D rb;
    GameObject player;
    bool tooCloseToPlayer = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            if (tooCloseToPlayer == false)
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;
                rb.MovePosition(rb.position + direction * eSpeed * Time.fixedDeltaTime);
            }
            else
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;
                rb.MovePosition(rb.position - direction * eSpeed * Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tooCloseToPlayer = true;
            Debug.Log("tooCloseToPlayer = true");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tooCloseToPlayer = false;
        }
    }
}
