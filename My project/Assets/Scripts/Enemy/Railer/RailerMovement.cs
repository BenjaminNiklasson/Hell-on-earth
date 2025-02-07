using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailerMovement : MonoBehaviour
{
    [SerializeField] float eSpeed = 3f;
    Rigidbody2D rb;
    GameObject player;
    bool tooCloseToPlayer = false;
    bool isGrounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player != null && isGrounded == true)
        {
            if (tooCloseToPlayer == true)
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
}
