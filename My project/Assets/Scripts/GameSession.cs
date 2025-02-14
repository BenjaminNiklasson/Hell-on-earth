using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameSession : MonoBehaviour
{
    bool _playerHasShotgun = false;
    bool _playerHasMinigun = false;
    bool level2Unlocked = false;
    bool level3Unlocked = false;
    bool level4Unlocked = false;
    public bool _noClip = false;
    public bool _godMode = false;

    private void Awake()
    {
        int numGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 3)
        {
            level2Unlocked = true;
        }
        if (currentSceneIndex == 4)
        {
            level3Unlocked = true;
        }
        if (currentSceneIndex == 5)
        {
            level4Unlocked = true;
        }

        if (_playerHasShotgun)
        {
            FindFirstObjectByType<PlayerShooting>().ActivateShotgun();
        }
        if (_playerHasMinigun)
        {
            FindFirstObjectByType<PlayerShooting>().ActivateMinigun();
        }

        if (level2Unlocked == true && currentSceneIndex == 1)
        {
            FindFirstObjectByType<OscarScript>().Level2Unlock();
        }
        if (level3Unlocked == true && currentSceneIndex == 1)
        {
            FindFirstObjectByType<OscarScript>().Level3Unlock();
        }
        if (level4Unlocked == true && currentSceneIndex == 1)
        {
            FindFirstObjectByType<OscarScript>().Level4Unlock();
        }
        if (_godMode == true)
        {
            FindFirstObjectByType<PlayerHealth>().GodMode();
        }
        if (_noClip == true)
        {
            FindFirstObjectByType<PlayerMovement>().NoClip();
        }
    }

    public void ActivateShotgun()
    {
        _playerHasShotgun = true;
    }
    public void ActivateMinigun()
    {
        _playerHasMinigun = true;
    }
}
