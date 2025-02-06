using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunPickUpp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindFirstObjectByType<GameSession>().ActivateMinigun();
        FindFirstObjectByType<PlayerShooting>().ActivateMinigun();
        Destroy(gameObject);
    }
    // When the object collides we unlock the minigun for the player and save the unlock in gamesession;
}
