using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool IsGrounded = false;
    GameObject player;
    [SerializeField] float eSpeed = 1f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (IsGrounded == true)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            direction.y =0;
            rb.MovePosition(rb.position + direction * eSpeed * Time.fixedDeltaTime);
            Debug.Log("Is Moving");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsGrounded = false;
        }
    }
}
