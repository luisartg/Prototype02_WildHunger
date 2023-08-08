using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] animalPrefabs;
    public SpawnDirection spawnDirection;
    public float spawnRange = 20;
    public float spawnDistance = 20;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = GetSpawnPosition();
        Quaternion spawnRotation = GetRotation(animalPrefabs[animalIndex].transform.rotation);

        Instantiate(
            animalPrefabs[animalIndex],
            spawnPosition,
            spawnRotation);
    }

    private Vector3 GetSpawnPosition()
    {
        float x, z;

        switch (spawnDirection) 
        {
            case SpawnDirection.Up:
                x = Random.Range(-spawnRange, spawnRange);
                z = spawnDistance;
                break;
            case SpawnDirection.Left:
                x = -spawnDistance;
                z = Random.Range(-spawnRange, spawnRange);
                break; 
            case SpawnDirection.Right:
                x = spawnDistance;
                z = Random.Range(-spawnRange, spawnRange);
                break;
            default:
                x = 0; 
                z = 0; 
                break;
        }
        return new(x, 0, z);
    }

    private Quaternion GetRotation(Quaternion currentRotation)
    {
        float yEulerAngle = currentRotation.eulerAngles.y;

        switch (spawnDirection) 
        {
            case SpawnDirection.Up:
                yEulerAngle = 180;
                break;
            case SpawnDirection.Left:
                yEulerAngle = 90;
                break;
            case SpawnDirection.Right:
                yEulerAngle = 270;
                break;
        }
        return Quaternion.Euler(currentRotation.eulerAngles.x, yEulerAngle, currentRotation.eulerAngles.z);
    }
}

public enum SpawnDirection
{
    Up,
    Left,
    Right
}
