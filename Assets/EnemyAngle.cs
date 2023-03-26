using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAngle : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Yakalandi - Game Over");
        }
    }
}
