using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAngle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Yakalandi - Game Over");
            //Time.timeScale = 0;
        }
    }
}
