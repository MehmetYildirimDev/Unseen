using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsMove : MonoBehaviour
{
    public float Rotatespeed = 3f;
    public float Movespeed = 4f;

    void Update()
    {
        transform.Rotate(Vector3.up, Rotatespeed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement.instance.isGameOver = true;
        }
    }
}
