using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForBarrier : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.green;
            Destroy(GameObject.Find("Barriermid"));

        }
    }


}
