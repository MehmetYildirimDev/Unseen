using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsMove : MonoBehaviour
{
    public float Rotatespeed = 3f;

    void Update()
    {
        transform.Rotate(Vector3.up, Rotatespeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.instance.isGameOver = true;
        }
    }
}
