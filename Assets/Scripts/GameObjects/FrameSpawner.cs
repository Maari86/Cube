using UnityEngine;

public class FrameSpawner : MonoBehaviour
{
    public GameObject objectToSpawn1;
    public GameObject objectToSpawn2;
    public GameObject objectToSpawn3;
    public GameObject objectToSpawn4;
    public Transform spawnPoint;
    public float timeInterval = 1f;
    public int numObjectsToSpawn1 = 5;
    public int numObjectsToSpawn2 = 5;
    public int numObjectsToSpawn3 = 5;
    public int numObjectsToSpawn4 = 5;
    private int objectsSpawned1 = 0;
    private int objectsSpawned2 = 0;
    private int objectsSpawned3 = 0;
    private int objectsSpawned4 = 0;

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, timeInterval);
    }

    void SpawnObject()
    {
        if (objectsSpawned1 < numObjectsToSpawn1)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn1, spawnPoint.position, spawnPoint.rotation);
            spawnedObject.transform.parent = transform;
            Destroy(spawnedObject, 17f);
            objectsSpawned1++;
        }
        else if (objectsSpawned2 < numObjectsToSpawn2)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn2, spawnPoint.position, spawnPoint.rotation);
            spawnedObject.transform.parent = transform;
            Destroy(spawnedObject, 17f);
            objectsSpawned2++;
        }
        else if (objectsSpawned3 < numObjectsToSpawn3)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn3, spawnPoint.position, spawnPoint.rotation);
            spawnedObject.transform.parent = transform;
            Destroy(spawnedObject, 17f);
            objectsSpawned3++;
        }
        else if (objectsSpawned4 < numObjectsToSpawn4)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn4, spawnPoint.position, spawnPoint.rotation);
            spawnedObject.transform.parent = transform;
            Destroy(spawnedObject, 17f);
            objectsSpawned4++;
        }

        if (objectsSpawned1 >= numObjectsToSpawn1 && objectsSpawned2 >= numObjectsToSpawn2 &&
            objectsSpawned3 >= numObjectsToSpawn3 && objectsSpawned4 >= numObjectsToSpawn4)
        {
            objectsSpawned1 = 0;
            objectsSpawned2 = 0;
            objectsSpawned3 = 0;
            objectsSpawned4 = 0;
        }
    }
}
