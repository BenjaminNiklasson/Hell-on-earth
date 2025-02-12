using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] int[] wavePoints;
    [SerializeField] bool[] aspidAvailable;
    [SerializeField] bool[] tankAvailable;
    [SerializeField] bool[] railgunnerAvailable;
    [SerializeField] GameObject aspid;
    [SerializeField] GameObject tank;
    [SerializeField] GameObject railgunner;
    [SerializeField] int coldownBetweenWaves;
    [SerializeField] float minSpawntime;
    [SerializeField] float maxSpawntime;
    [SerializeField] float spawnDistance;
    Vector2 screenBounds;
    Vector2 spawnPosition;
    int currentWave = 0;
    Vector2 minBounds;
    Vector2 maxBounds;
    Vector2 center;
    Vector2 size;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        Collider2D myCollider = GetComponent<Collider2D>();
        Bounds colliderBounds = myCollider.bounds;

        minBounds = colliderBounds.min; // Bottom-left
        maxBounds = colliderBounds.max; // Top-right
        center = colliderBounds.center; // Center position
        size = colliderBounds.size; // Width & Height
    }

    void SpawnEnemy()
    {
        if (wavePoints[currentWave] >= 1)
        {
            float spawnTime = Random.Range(minSpawntime, maxSpawntime);
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            Vector2 screenDifferens = new Vector2((screenBounds.x - screenBounds.x), (screenBounds.y - screenBounds.y));
            int lOrR;

            int type = Random.Range(0, 3);
            switch (type)
            {
                case 0:
                    if (aspidAvailable[currentWave])
                    {
                        int side = Random.Range(0, 3);
                        switch (side)
                        {
                            case 0:
                                spawnPosition = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + spawnDistance);
                                break;
                            case 1:
                                spawnPosition = new Vector2(screenBounds.x + spawnDistance, Random.Range(-screenBounds.y, screenBounds.y));
                                break;
                            case 2:
                                spawnPosition = new Vector2(-screenBounds.x - spawnDistance, Random.Range(-screenBounds.y, screenBounds.y));
                                break;
                        }
                        GameObject currentAspid = Instantiate(aspid, spawnPosition, transform.rotation);
                        if (currentAspid.transform.position.x < maxBounds.x && currentAspid.transform.position.x > minBounds.x && currentAspid.transform.position.y < maxBounds.y && currentAspid.transform.position.y > minBounds.y) 
                        {
                            Invoke("SpawnEnemy", spawnTime);
                            wavePoints[currentWave]--;
                        }
                        else
                        {
                            Destroy(currentAspid);
                            Invoke("SpawnEnemy", 0);
                        }
                        if (wavePoints[currentWave] < 1)
                        {
                            currentWave = (currentWave + 1);
                            Invoke("SpawnEnemy", coldownBetweenWaves);
                        }
                        break;
                    }
                    else
                    {
                        Invoke("SpawnEnemy", 0);
                        break;
                    }
                case 1:
                    if (tankAvailable[currentWave])
                    {
                        lOrR = Random.Range(0, 2);
                        switch (lOrR)
                        {
                            case 0:
                                spawnPosition = new Vector2(Random.Range(screenBounds.x, (screenBounds.x + spawnDistance)), ((screenBounds.y - screenDifferens.y) / 2) + screenDifferens.y);
                                break;
                            case 1:
                                spawnPosition = new Vector2(Random.Range(-screenBounds.x, (-screenBounds.x - spawnDistance)), ((screenBounds.y - screenDifferens.y) / 2) + screenDifferens.y);
                                break;
                        }
                        GameObject currentTank = Instantiate(tank, spawnPosition, transform.rotation);
                        if (currentTank.transform.position.x < maxBounds.x && currentTank.transform.position.x > minBounds.x && currentTank.transform.position.y < maxBounds.y && currentTank.transform.position.y > minBounds.y)
                        {
                            Invoke("SpawnEnemy", spawnTime);
                            wavePoints[currentWave] -= 3;
                        }
                        else
                        {
                            Destroy(currentTank);
                            Invoke("SpawnEnemy", 0);
                        }
                        if (wavePoints[currentWave] < 1)
                        {
                            currentWave = (currentWave + 1);
                            Invoke("SpawnEnemy", coldownBetweenWaves);
                        }
                        break;
                    }
                    else
                    {
                        Invoke("SpawnEnemy", 0);
                        break;
                    }
                case 2:
                    if (railgunnerAvailable[currentWave])
                    {
                        lOrR = Random.Range(0, 2);
                        switch (lOrR)
                        {
                            case 0:
                                spawnPosition = new Vector2(Random.Range(screenBounds.x, (screenBounds.x + spawnDistance)), ((screenBounds.y - screenDifferens.y) / 2) + screenDifferens.y);
                                break;
                            case 1:
                                spawnPosition = new Vector2(Random.Range(-screenBounds.x, (-screenBounds.x - spawnDistance)), ((screenBounds.y - screenDifferens.y) / 2) + screenDifferens.y);
                                break;
                        }
                        GameObject currentRailer = Instantiate(railgunner, spawnPosition, transform.rotation);
                        if (currentRailer.transform.position.x < maxBounds.x && currentRailer.transform.position.x > minBounds.x && currentRailer.transform.position.y < maxBounds.y && currentRailer.transform.position.y > minBounds.y)
                        {
                            Invoke("SpawnEnemy", spawnTime);
                            wavePoints[currentWave] -= 2;
                        }
                        else
                        {
                            Destroy(currentRailer);
                            Invoke("SpawnEnemy", 0);
                        }
                        if (wavePoints[currentWave] < 1)
                        {
                            currentWave = (currentWave + 1);
                            Invoke("SpawnEnemy", coldownBetweenWaves);
                        }
                        break;
                    }
                    else
                    {
                        Invoke("SpawnEnemy", 0);
                        break;
                    }
            }
        }
    }
}
