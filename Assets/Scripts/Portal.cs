using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform SpawnPoint;
    private GameObject PortalExit;
    [SerializeField] private GameObject EffectPrefab;
    private void Start()
    {
        PortalExit = GameObject.Find("PortalExit");
        SpawnPoint = PortalExit.transform.GetChild(0).transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = SpawnPoint.position;

            GameObject Effect = Instantiate(EffectPrefab,
                new Vector3(SpawnPoint.position.x,SpawnPoint.position.y+2,SpawnPoint.position.z),
                Quaternion.identity);

            Destroy(Effect, 1f);
        }
    }
}
