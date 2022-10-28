using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemy : MonoBehaviour
{
    //public float lookRadius = 10.0f;
    public NavMeshAgent agent;
    public Transform final;
    
    void Start()
    {
        
    }

    void Update()
    {
        agent.SetDestination(final.position);
    }

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }*/
}
