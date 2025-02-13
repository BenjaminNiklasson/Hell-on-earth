using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 moveimput;
    Rigidbody2D rb;
    [SerializeField] ContactFilter2D groundFilter;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpSpeed = 20f;
    bool IsGrounded;
    [SerializeField]int maxNumberOfJumps = 1;
    int numberOfJumps = 0;
    Animator ani;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //numberOfJumps = maxNumberOfJumps;
        ani = GetComponent<Animator>();
        ani.SetBool("IsRunning", false);
    }

    void OnFire()
    {
        Debug.Log("Fire!");
    }

    void OnMove(InputValue value)
    {
        moveimput = value.Get<Vector2>();
        Debug.Log(moveimput);
    }

    void OnJump()
    {
        if (numberOfJumps > 0)
        {
            rb.velocity = new Vector2(0f, jumpSpeed);
            numberOfJumps -= 1;
        }
    }

    private void FixedUpdate()
    {
        IsGrounded = rb.IsTouching(groundFilter);
        if(IsGrounded ==true)
        {
            numberOfJumps = maxNumberOfJumps;
        }
    }


    void Update()
    {
        rb.velocity = new Vector2(moveimput.x * moveSpeed, rb.velocity.y);
        if(moveimput.x !=0)
        {
            ani.SetBool("IsRunning", true);
            transform.localScale = new Vector2(Mathf.Sign(moveimput.x), transform.localScale.y);
        }
        else
        {
            ani.SetBool("IsRunning", false);
        }
    }
}

