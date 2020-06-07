using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawner : MonoBehaviour
{
    public float xMinRange = -25.0f;
    public float xMaxRange = 25.0f;
    public float yMinRange = 8.0f;
    public float yMaxRange = 25.0f;
    public float zMinRange = -25.0f;
    public float zMaxRange = 25.0f;

    public float secondsBetweenSpawning = 0.1f;

    public GameObject[] spawnObjects;

    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + secondsBetweenSpawning;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm) {
            if (GameManager.gm.gameIsOver) {
                return;
            }
        }

        if (Time.time >= nextSpawnTime) {
            nextSpawnTime = Time.time + secondsBetweenSpawning;
            SpawnThings();
        }
    }

    private void SpawnThings() {
        Vector3 spawnPosition;
        spawnPosition.x = Random.Range(xMinRange, xMaxRange);
        spawnPosition.y = Random.Range(yMinRange, yMaxRange);
        spawnPosition.z = Random.Range(zMinRange, zMaxRange);

        int objectToSpawn = Random.Range(0, spawnObjects.Length);

        GameObject spawnedObject = Instantiate(spawnObjects[objectToSpawn], spawnPosition, transform.rotation);
        
        spawnedObject.transform.parent = gameObject.transform;
    }
}
