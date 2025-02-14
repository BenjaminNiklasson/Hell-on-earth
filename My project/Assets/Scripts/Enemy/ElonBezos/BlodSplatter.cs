using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlodSplatter : MonoBehaviour
{
    [SerializeField] bool isRight;
    [SerializeField] bool isLeft;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }
}
