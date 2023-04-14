using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFov : MonoBehaviour
{

    [Header("Field of View")]
    public float FovRadius;
    [Range(0, 360)] public float FovAngle;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;

    private Transform target;

    private void Start()
    {
        target = PlayerMovement.instance.transform;
    }

    private void Update()
    {
        FOVChechk();
    }
    private void FOVChechk()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, FovRadius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directonToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directonToTarget) < FovAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directonToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)//daha once gorduyse býrakýyo
            canSeePlayer = false;
    }
}
