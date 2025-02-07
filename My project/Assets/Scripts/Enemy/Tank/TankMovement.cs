using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] ContactFilter2D groundFilter;
    Vector2 moveimput;
    Rigidbody2D rb;
    bool IsGrounded;
    GameObject player;
    [SerializeField] float eSpeed = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }
    private void FixedUpdate()
    {
        IsGrounded = rb.IsTouching(groundFilter);
        if (IsGrounded == true)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * eSpeed * Time.fixedDeltaTime);
        }
    }

    void Update()
    {
        
    }
}
