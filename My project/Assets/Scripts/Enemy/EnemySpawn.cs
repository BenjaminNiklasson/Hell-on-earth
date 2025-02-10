using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] int numWaves;
    [SerializeField] int[] wavePoints;
    [SerializeField] bool aspidAvailable;
    [SerializeField] bool tankAvailable;
    [SerializeField] bool railgunnerAvailable;
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

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        float spawnTime = Random.Range(minSpawntime, maxSpawntime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        int type = Random.Range(0, 3);
        switch (type)
        {
            case 0:
                int side = Random.Range(0, 3);
                switch (side)
                {
                    case 0:
                        spawnPosition = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y);
                        break;
                    case 1:
                        spawnPosition = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
                        break;
                    case 2:
                        spawnPosition = new Vector2(-screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
                        break;
                }
                Instantiate(aspid, spawnPosition, transform.rotation);
                Invoke("SpawnEnemy", spawnTime);
                wavePoints[currentWave]--;
                if (wavePoints[currentWave] < 1)
                {
                    currentWave = (currentWave + 1);
                }
                break;
            case 1:
                Vector2 screenDifferens = new Vector2((screenBounds.x-screenBounds.x), (screenBounds.y-screenBounds.y));
                int lOrR = Random.Range(0, 2);
                switch (lOrR)
                {
                    case 0:
                        spawnPosition = new Vector2(Random.Range(screenBounds.x, (screenBounds.x + 10)), ((screenBounds.y - screenDifferens.y)/2) + screenDifferens.y);
                        break;
                    case 1:
                        spawnPosition = new Vector2(Random.Range(-screenBounds.x, (-screenBounds.x - 10)), ((screenBounds.y - screenDifferens.y) / 2) + screenDifferens.y);
                        break;
                }
                Instantiate(tank, spawnPosition, transform.rotation);
                Invoke("SpawnEnemy", spawnTime);
                wavePoints[currentWave] -= 3;
                if (wavePoints[currentWave] < 1)
                {
                    currentWave = (currentWave + 1);
                }
                break;
            case 2:
                Invoke("SpawnEnemy", spawnTime/3);
                break;
        }
    }
}
