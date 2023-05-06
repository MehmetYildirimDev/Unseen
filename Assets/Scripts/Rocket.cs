using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 5f;
    public GameObject impactEffectPrefab;

    [SerializeField] private AudioClip explosionClip;
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ScaleBuff"))
        {
            return;
        }


        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.instance.isGameOver = true;
        }

        if (collision.gameObject.CompareTag("RocketSpawner"))
        {
            return;
        }

        SoundManager.instance.PlaySound(explosionClip);

        GameObject impactEffect = Instantiate(impactEffectPrefab, collision.contacts[0].point, Quaternion.identity);
        Destroy(impactEffect, 1f);
        Destroy(this.gameObject);
    }
}
