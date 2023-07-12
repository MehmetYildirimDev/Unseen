using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject LockDoors;
    [SerializeField] private AudioClip clip;

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
                try
                {
                    SoundManager.instance.PlaySound(clip);
                }
                catch (System.Exception)
                {
                    print("sound manager yok");
                }
                Destroy(this.gameObject);
            }
        }
        catch (System.Exception)
        {
            Debug.Log("LockDoor Scripti Bulunamadi");   
        }

    }
}
