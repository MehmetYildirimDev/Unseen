using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;
    public List<GameObject> dots;


    private Transform target;
    private int index;

    public float distance;

    public EnemyFov enemyFovScript;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        index = 1;
        enemyFovScript = gameObject.GetComponent<EnemyFov>();
    }

    private void Start()
    {
        
        target = dots[index].transform;
        agent.SetDestination(target.position);
    }

    private void Update()
    {
        if (enemyFovScript.canSeePlayer)
        {
            //agent.SetDestination(enemyFovScript.target.position);
            GameOver();
            
            return;
        

        }

        


        if (agent.remainingDistance <= agent.stoppingDistance)
        {

            if (index == 0)
            {
                index = 1;

            }
            else if (index == 1)
            {
                index = 0;

            }
            agent.SetDestination(dots[index].transform.position);
        }


    }

    private void GameOver()
    {
        Debug.Log("oyun bitti");
        agent.isStopped = true;
        GetComponent<Animator>().Play("EnemyCatch");
        PlayerMovement.instance.isGameOver = true;

    }
}
