using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickUpp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Has collided");
            FindFirstObjectByType<GameSession>().ActivateShotgun();
            FindFirstObjectByType<PlayerShooting>().ActivateShotgun();
            Destroy(gameObject);
        }
    }
    // When the object collides we unlock the shotgun for the player and save the unlock in gamesession;
}
