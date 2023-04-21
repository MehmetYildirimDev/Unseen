using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.Rotate(Vector3.up, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement.instance.isGameOver = true;
        }
    }
}
