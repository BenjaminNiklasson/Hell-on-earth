using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    [SerializeField] public bool noClip;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //numberOfJumps = maxNumberOfJumps;
        ani = GetComponent<Animator>();
        ani.SetBool("IsRunning", false);
        if (noClip)
        {
            rb.gravityScale = 0;
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    void OnFire()
    {
        Debug.Log("Fire!");
    }

    void OnMove(InputValue value)
    {
        moveimput = value.Get<Vector2>();
        Debug.Log(moveimput);
        if (noClip)
        {
            rb.gravityScale = 0;
            GetComponent<PolygonCollider2D>().enabled = false;
        }
        else
        {
            rb.gravityScale = 1;
            GetComponent<PolygonCollider2D>().enabled = true;
        }
    }

    void OnJump()
    {
        if (numberOfJumps > 0)
        {
            rb.velocity = new Vector2(0f, jumpSpeed);
            numberOfJumps -= 1;
            Invoke(nameof(SetJump), 0.1f);
        }
    }

    private void FixedUpdate()
    {
        IsGrounded = rb.IsTouching(groundFilter);
        if(IsGrounded ==true)
        {
            numberOfJumps = maxNumberOfJumps;
            
        }
        ani.SetBool("IsGrounded", IsGrounded);
    }


    void Update()
    {
        if (!noClip)
        {
            rb.velocity = new Vector2(moveimput.x * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveimput.x * moveSpeed, moveimput.y * moveSpeed);
        }

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

    void SetJump()
    {
        ani.SetTrigger("Jump");
    }

    public void NoClip()
    {
        noClip = true;
    }
}

