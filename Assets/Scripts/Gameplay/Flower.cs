using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Can verildi");
            collision.transform.localScale += Vector3.one;
            PlayerMovement.instance.playerScale++;
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("kendimi yok ettim");
    }
}
