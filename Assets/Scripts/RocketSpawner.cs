using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject Rocket;
    public Transform spawnPoint;
    public float spawnDelay = 1f;

    void Start()
    {
        SpawnObject();
        InvokeRepeating("SpawnObject", spawnDelay, spawnDelay);
    }

    void SpawnObject()
    {
        GetComponent<Animation>().Play("RocketSpawnerAnim");
        Instantiate(Rocket, spawnPoint.position, this.transform.rotation);
        
    }
}
