using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public EnemyFov enemyFovScript;

    private void Start()
    {
        enemyFovScript = gameObject.GetComponent<EnemyFov>();
    }

    private void Update()
    {
        if (enemyFovScript.canSeePlayer)
        {
            PlayerController.instance.isGameOver = true;
            GetComponentInParent<Animation>().Stop();
        }
    }


}
