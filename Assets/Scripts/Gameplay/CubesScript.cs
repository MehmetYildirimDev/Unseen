using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int playerScale = PlayerController.instance.playerScale;

            if (playerScale > 0)
            {
                Debug.Log("cubescript calisiyo");
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                this.gameObject.GetComponent<CubesScript>().enabled = false;
            }

        }
    }


}
