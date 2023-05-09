using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guillotine : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerController.instance.isGameOver = true;
        }
    }
}
