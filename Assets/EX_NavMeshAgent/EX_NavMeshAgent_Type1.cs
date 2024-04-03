using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EX_NavMeshAgent_Type1 : MonoBehaviour
{
    public Transform Target;
    NavMeshAgent Agent;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();        
    }

    void Update()
    {
        Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.forward * 10, Color.red);
        Agent.destination = Target.position;        
    }
}
