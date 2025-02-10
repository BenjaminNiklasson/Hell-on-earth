using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunPickUpp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            FindFirstObjectByType<GameSession>().ActivateMinigun();
            FindFirstObjectByType<PlayerShooting>().ActivateMinigun();
            Destroy(gameObject);
            Debug.Log("Has collided");
        }
    }
    // When the object collides we unlock the minigun for the player and save the unlock in gamesession;
}
