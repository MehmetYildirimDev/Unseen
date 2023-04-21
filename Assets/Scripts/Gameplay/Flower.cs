using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Can verildi");
            other.transform.localScale += Vector3.one / 2;
            PlayerMovement.instance.playerScale++;
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        Debug.Log("kendimi yok ettim");
    }
}
