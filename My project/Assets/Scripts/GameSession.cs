using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    bool _playerHasShotgun = false;
    bool _playerHasMinigun = false;

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
        if (_playerHasShotgun)
        {
            FindFirstObjectByType<PlayerShooting>().ActivateShotgun();
        }
        if (_playerHasMinigun)
        {
            FindFirstObjectByType<PlayerShooting>().ActivateMinigun();
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
