using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EX_NavMeshAgent_Type1A : MonoBehaviour
{
    NavMeshAgent Agent;

    public List<Transform> PatrolPoints = new List<Transform>();
    int currentDestination = 0;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.destination = PatrolPoints[currentDestination].position;
        print(PatrolPoints.Count);
    }

    void Update()
    {
        
        //float distance = Vector3.Distance(Agent.transform.position, PatrolPoints[currentDestination].position);
        ////print(distance);
        //if (distance < 1)
        //{
        //    currentDestination++;
        //    if (currentDestination >= PatrolPoints.Count)
        //    {
        //        currentDestination = 0;
        //    }
        //    Agent.destination = PatrolPoints[currentDestination].position;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);
        //print(currentDestination);
        //if (collision.gameObject.name == PatrolPoints[currentDestination].name)
        //{
        //    currentDestination++;
        //    if (currentDestination >= PatrolPoints.Count)
        //    {
        //        currentDestination = 0;
        //    }
        //    Agent.destination = PatrolPoints[currentDestination].position;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.name == PatrolPoints[currentDestination].name)
        {
            //currentDestination++;            
            //if (currentDestination >= PatrolPoints.Count)
            //{
            //    currentDestination = 0;
            //}
            int nextDestination = currentDestination;
            while (nextDestination == currentDestination)
            {
                nextDestination = Random.Range(0, PatrolPoints.Count);
            }
            print(currentDestination + ", " + nextDestination);
            currentDestination = nextDestination;
            Agent.destination = PatrolPoints[currentDestination].position;
        }
    }
}
