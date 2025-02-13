using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElonShooting : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject player;
    [SerializeField] float spawnDistance = 5f;
    Vector2 screenBounds;
    Vector2 spawnPos;
    bool bool1 = false;

    void spawnOrb()
    {
        enemyPrefab = Instantiate(enemyPrefab, new Vector2(player.transform.position.x,transform.position.y), transform.rotation);
    }
    
    void Update()
    {
        if (bool1 == false)
        {
            spawnOrb();
            Invoke("Coldown", 5);
            bool1 = true;
        }
    }
    
    void Coldown()
    {
        bool1 = false;
    }
}
