using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    private GameObject[] doors = new GameObject[2];
    //bu objenin collideri kapanicak doorslarýn collideri acilicak => anahtarý alinca

    public Material defultDoorMat;

    private void Start()
    {
        doors[0] = transform.GetChild(0).gameObject;
        doors[1] = transform.GetChild(1).gameObject;
    }

    public void OpenLockDoor()
    {
        print("open the door");
        GetComponent<BoxCollider>().enabled = false;
        foreach (var item in doors)
        {
            item.GetComponent<BoxCollider>().enabled = true;
            item.GetComponent<MeshRenderer>().materials[1].color = defultDoorMat.color;

        }



    }


}
