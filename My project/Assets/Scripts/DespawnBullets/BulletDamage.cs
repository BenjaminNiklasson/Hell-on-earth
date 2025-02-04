using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject)
        {
            Destroy(gameObject);
        }
        //Destroys the object it collides with and istself if tuching an enemy and only itself if tuching anything else.
        //It does not dissapear when overlaping anything on the "player" layer since the "bullet" and "player" layer doesn't collide.
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        // Destroy the bullet off-screan.
    }
}
