using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public List<int> spawnXs = new List<int>();

    public float origTimeRemainingToSpawn = 6.0f;
    public float timeRemainingToSpawn = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnXs.Add(0);
        spawnXs.Add(5);
        spawnXs.Add(-5);
        SpawnPlatform();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeRemainingToSpawn -= Time.fixedDeltaTime;
        if (timeRemainingToSpawn <= 0)
        {
            SpawnPlatform();
            timeRemainingToSpawn = origTimeRemainingToSpawn;
        }
    }

    private void SpawnPlatform()
    {
        int spawnLocIdx = UnityEngine.Random.Range(0, 3);
        Vector3 pos = new Vector3(spawnXs[spawnLocIdx], 6, 0);
        GameObject platform = Instantiate(platformPrefab, pos, transform.rotation);
    }
}
