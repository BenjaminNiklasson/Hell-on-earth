using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 1;
    [SerializeField] float invincibilityTime = 2f;
    [SerializeField] bool godMode;
    bool invincible = false;

    void DisableInvincibility()
    {
        invincible = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            if (invincible == true)
            {
                return;
            }
            if (playerHealth > 0)
            {
                playerHealth--;
                invincible = true;
                Invoke("DisableInvincibility", invincibilityTime);
                Debug.Log("Player health:" + playerHealth);
            }
            else
            {
                if (!godMode)
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
        else
        {
            return;
        }
    }
    public int GetHealth()
    {
        return playerHealth;
    }
}
