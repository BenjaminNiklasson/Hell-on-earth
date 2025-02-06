using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickUpp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            //FindFirstObjectByType<GameSession>().ActivateShotgun();
            FindFirstObjectByType<PlayerShooting>().ActivateShotgun();
            Destroy(gameObject);
            Debug.Log("Has collided");
        }
    }
    // When the object collides we unlock the shotgun for the player and save the unlock in gamesession;
}
