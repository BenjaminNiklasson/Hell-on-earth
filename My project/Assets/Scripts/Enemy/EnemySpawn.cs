using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] bool hellmodeOn;
    Vector2 screenBounds;
    Vector2 spawnPosition;
    public int currentWave = 0;
    Vector2 minBounds;
    Vector2 maxBounds;
    Vector2 center;
    Vector2 size;
    public int maxWaves;


    // Start is called before the first frame update
    void Start()
    {
        Collider2D myCollider = GetComponent<Collider2D>();
        Bounds colliderBounds = myCollider.bounds;
        maxWaves = wavePoints.Count();

        minBounds = colliderBounds.min; // Bottom-left
        maxBounds = colliderBounds.max; // Top-right
        center = colliderBounds.center; // Center position
        size = colliderBounds.size; // Width & Height
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (wavePoints[currentWave] >= 0)
        {
            float spawnTime = Random.Range(minSpawntime, maxSpawntime);
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            int lOrR;

            float type = Random.Range(0, 18);
            if (type < 12)
            {
                    Debug.Log("0-11");
                    if (aspidAvailable[currentWave])
                    {
                        Debug.Log("TryingAspid");
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
                            if (hellmodeOn && currentWave == maxWaves)
                            {
                                maxSpawntime = maxSpawntime / 2;
                                minSpawntime = minSpawntime / 3;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("SpawnEnemy()");
                        Invoke("SpawnEnemy", 0);
                    }
            }
            else if ()
                    Debug.Log("12-15");
                    if (tankAvailable[currentWave])
                    {
                        Debug.Log("TryingTank");
                        lOrR = Random.Range(0, 2);
                        switch (lOrR)
                        {
                            case 0:
                                spawnPosition = new Vector2(Random.Range(screenBounds.x, (screenBounds.x + spawnDistance)), screenBounds.y);
                                break;
                            case 1:
                                spawnPosition = new Vector2(Random.Range(-screenBounds.x, (-screenBounds.x - spawnDistance)), screenBounds.y);
                                break;
                        }
                        GameObject currentTank = Instantiate(tank, spawnPosition, transform.rotation);
                        if (currentTank.transform.position.x < maxBounds.x && currentTank.transform.position.x > minBounds.x && currentTank.transform.position.y < maxBounds.y && currentTank.transform.position.y > minBounds.y)
                        {
                            Invoke("SpawnEnemy", spawnTime);
                            wavePoints[currentWave] -= 4;
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
                            if (hellmodeOn && currentWave == maxWaves)
                            {
                                maxSpawntime = maxSpawntime / 2;
                                minSpawntime = minSpawntime / 3;
                            }
                        }
                        break;
                    }
                    else
                    {
                        Debug.Log("SpawnEnemy()");
                        Invoke("SpawnEnemy", 0);
                        break;
                    }
                case 16-18:
                    Debug.Log("15-18");
                    if (railgunnerAvailable[currentWave])
                    {
                        Debug.Log("TryingRailer");
                        lOrR = Random.Range(0, 2);
                        switch (lOrR)
                        {
                            case 0:
                                spawnPosition = new Vector2(Random.Range(screenBounds.x, (screenBounds.x + spawnDistance)), screenBounds.y);
                                break;
                            case 1:
                                spawnPosition = new Vector2(Random.Range(-screenBounds.x, (-screenBounds.x - spawnDistance)), screenBounds.y);
                                break;
                        }
                        GameObject currentRailer = Instantiate(railgunner, spawnPosition, transform.rotation);
                        if (currentRailer.transform.position.x < maxBounds.x && currentRailer.transform.position.x > minBounds.x && currentRailer.transform.position.y < maxBounds.y && currentRailer.transform.position.y > minBounds.y)
                        {
                            Invoke("SpawnEnemy", spawnTime);
                            wavePoints[currentWave] -= 3;
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
                            if (hellmodeOn && currentWave == maxWaves)
                            {
                                maxSpawntime = maxSpawntime / 2;
                                minSpawntime = minSpawntime / 3;
                            }
                        }
                        break;
                    }
                    else
                    {
                        Debug.Log("SpawnEnemy()");
                        Invoke("SpawnEnemy", 0);
                        break;
                    }
            }
        }
    }
}
