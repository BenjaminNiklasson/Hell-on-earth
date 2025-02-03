using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 moveimput;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
  

    void Update()
    {
        rb.velocity = new Vector2(moveimput.x * moveSpeed, rb.velocity.y);
    }
}

