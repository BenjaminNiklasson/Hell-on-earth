using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElonShooting : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject player;
    [SerializeField] float spawnDistance = 5f;
    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;
    Vector2 screenBounds;
    Vector2 spawnPos;
    bool isOnColdown = false;

    void spawnOrb()
    {
        enemyPrefab = Instantiate(enemyPrefab, new Vector2(player.transform.position.x,transform.position.y), transform.rotation);
    }
    
    void Update()
    {
        if (isOnColdown == false)
        {
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            spawnOrb();
            Invoke("Coldown", spawnTime);
            isOnColdown = true;
        }
    }
    
    void Coldown()
    {
        isOnColdown = false;
    }
}
