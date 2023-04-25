using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject LockDoors;
    private void Start()
    {
         LockDoors = GameObject.Find("LockDoors");
    }
    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.CompareTag("Player"))
            {
                LockDoors.GetComponent<LockDoor>().OpenLockDoor();
                Destroy(this.gameObject);
            }
        }
        catch (System.Exception)
        {
            Debug.Log("LockDoor Scripti Bulunamadi");   
        }

    }
}
