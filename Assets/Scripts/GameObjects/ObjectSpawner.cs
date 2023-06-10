using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnDelay = 1.0f;
    public float destroyDelay = 5.0f;
    public Transform[] spawnPoints;
    [HideInInspector]
    public bool isSpawnEnabled = true;

    public void SpawnObjects(int path, int objectIndex)
    {
        //Debug.Log("Path: " + path +", index: " + objectIndex);
        if (path != 0 && isSpawnEnabled)
        {
            // Create the object as a child of the spawner
            GameObject spawnedObject = Instantiate(objectsToSpawn[objectIndex], spawnPoints[path - 1].position, spawnPoints[path - 1].rotation, transform);
            spawnedObject.name = "SpawnedObject";
            Destroy(spawnedObject, destroyDelay);
        }
    }

    public void SpawnObjects(int path, int objectIndex, bool isGem)
    {
        //Debug.Log("Path: " + path + ", index: " + objectIndex);
        if (path != 0 && isSpawnEnabled)
        {
            // Create the object as a child of the spawner
            GameObject spawnedObject = Instantiate(objectsToSpawn[objectIndex], spawnPoints[path - 1].position, spawnPoints[path - 1].rotation, transform);
            spawnedObject.name = "SpawnedObject";
            Destroy(spawnedObject, destroyDelay);
        }
    }
}
