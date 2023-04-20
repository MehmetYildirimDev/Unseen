using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject Rocket;
    public Transform spawnPoint;
    public float spawnDelay = 2f;

    void Start()
    {
        Instantiate(Rocket, spawnPoint.position, Quaternion.identity);
        InvokeRepeating("SpawnObject", spawnDelay, spawnDelay);
    }

    void SpawnObject()
    {
        Instantiate(Rocket, spawnPoint.position, Quaternion.identity);
    }
}
