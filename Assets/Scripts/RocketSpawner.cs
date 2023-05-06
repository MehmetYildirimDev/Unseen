using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject Rocket;
    public Transform spawnPoint;
    public float spawnDelay = 1f;

    [SerializeField] private AudioClip shootClip;

    void Start()
    {
        SpawnObject();
        InvokeRepeating("SpawnObject", spawnDelay, spawnDelay);
    }

    private void Update()
    {
        if (PlayerController.instance.isGameOver)
        {
            CancelInvoke();
        }
    }

    void SpawnObject()
    {
        SoundManager.instance.PlaySound(shootClip);
        GetComponent<Animation>().Play("RocketSpawnerAnim");
        Instantiate(Rocket, spawnPoint.position, this.transform.rotation);
        
    }
}
