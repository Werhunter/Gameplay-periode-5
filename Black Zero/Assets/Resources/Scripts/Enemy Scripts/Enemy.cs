using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public Transform target;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.SetDestination(target.position);

        //Physics.OverlapSphere(this.transform.position, 1, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<Player_Health>().CurrentPlayerHealth -= 30f;
            other.GetComponentInChildren<Player_Health>().FadeTimerIsActive = true;
            this.gameObject.SetActive(false);
        }
    }

   
}
