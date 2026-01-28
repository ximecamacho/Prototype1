using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject goodPrefab;
    public GameObject badPrefab;
    public List<int> spawnXs = new List<int>();

    float origTimeRemainingToSpawn = 3.0f;
    float timeRemainingToSpawn = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnXs.Add(0);
        spawnXs.Add(5);
        spawnXs.Add(-5);
        // SpawnPlatform();
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

        Vector3 offset = new Vector3(0, 0.5f, 0);
        int spawnItemIdx = UnityEngine.Random.Range(0, 4);
        if (spawnItemIdx <= 2)
        {
            //spawn good
            GameObject item = Instantiate(goodPrefab, pos + offset, transform.rotation);
            item.transform.parent = platform.transform;
        }
        else
        {
            //spawn bad
            GameObject item = Instantiate(badPrefab, pos + offset, transform.rotation);
            item.transform.parent = platform.transform;
        }
    }
}
