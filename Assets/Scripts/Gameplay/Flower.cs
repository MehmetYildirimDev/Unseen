using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] private AudioClip ScaleUpclip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            try
            {
                SoundManager.instance.PlaySound(ScaleUpclip);
            }
            catch (System.Exception)
            {
                print("sound manager yok");
            }

            Debug.Log("Player Can verildi");
            other.transform.localScale += Vector3.one / 2;
            PlayerController.instance.playerScale++;
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        Debug.Log("kendimi yok ettim");
    }
}
