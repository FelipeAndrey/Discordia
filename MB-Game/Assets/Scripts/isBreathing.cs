using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class isBreathing : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    void Update()
    {
        animator.SetBool("Breathing", navMeshAgent.velocity.magnitude <= .1f);
    }
}
