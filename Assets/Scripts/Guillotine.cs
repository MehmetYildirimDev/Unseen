using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guillotine : MonoBehaviour
{
    public GameObject BloodPrefab;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            PlayerMovement.instance.isGameOver = true;
            GameObject blood = Instantiate(BloodPrefab, other.ClosestPoint(transform.position), Quaternion.identity);
            Destroy(blood, 1f);
        }
    }
}
