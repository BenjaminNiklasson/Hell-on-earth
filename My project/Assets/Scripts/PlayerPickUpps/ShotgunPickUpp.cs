using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickUpp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindFirstObjectByType<GameSession>().ActivateShotgun();
        FindFirstObjectByType<PlayerShooting>().ActivateShotgun();
        Destroy(gameObject);
    }
    // When the object collides we unlock the shotgun for the player and save the unlock in gamesession;
}
