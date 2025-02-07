using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] int numWaves;
    [SerializeField] int wave1Points;
    [SerializeField] int wave2Points;
    [SerializeField] int wave3Points;
    [SerializeField] int wave4Points;
    [SerializeField] int wave5Points;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
