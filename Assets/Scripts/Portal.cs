using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform SpawnPoint;
    public GameObject PortalExit;
    private GameObject PortalCover;
    [SerializeField] private GameObject EffectPrefab;

    [SerializeField] private AudioClip clip;
    private void Start()
    {
        SpawnPoint = PortalExit.transform.GetChild(0).transform;
        PortalCover = PortalExit.transform.GetChild(3).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            try
            {
                SoundManager.instance.PlaySound(clip);
            }
            catch (System.Exception)
            {
                print("sound manager yok");
            }
            

            other.transform.position = SpawnPoint.position;

            PortalCover.GetComponent<Animation>().Play("PortalExitCoverAnim");

            GameObject Effect = Instantiate(EffectPrefab,
                new Vector3(SpawnPoint.position.x,SpawnPoint.position.y+2,SpawnPoint.position.z),
                Quaternion.identity);


            Destroy(Effect, 1f);
        }
    }
}
