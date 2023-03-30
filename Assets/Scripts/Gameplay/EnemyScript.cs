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

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        index = 1;
        target = dots[index].transform;
        agent.SetDestination(target.position);
    }

    private void Update()
    {
        /*

            distance = Vector3.Distance(transform.position, target.position);


            if (distance < 0.1f)
            {
                if (index == 0)
                {
                    index = 1;
                    agent.isStopped = true;
                }
                else if (index == 1)
                {
                    index = 0;
                    agent.isStopped = true;
                }
            }
            agent.isStopped = false;
         */



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

        Debug.Log(distance + " " + index);




    }


    

}
