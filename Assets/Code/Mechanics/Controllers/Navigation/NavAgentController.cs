﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavAgentController : MonoBehaviour {

    #region Components
    Animator animator;
    [SerializeField]
    private NavMeshAgent navAgent;

    public List<Transform> patrolPoints;
    private int currentPatrolPoint = 0;
    public int nextWayPoint;
    #endregion

    #region Fields / Properties      

    #endregion
    public float MoveVelocity;
    public Vector3 destination;

    [SerializeField]
    private float distanceToDestination;
    public float DistanceToDestination
    {
        get
        {
            distanceToDestination = Vector3.Distance(navAgent.destination, gameObject.transform.position);
            return distanceToDestination;
        }
    }
    // Use this for initialization
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveVelocity = navAgent.velocity.magnitude;
        //MovementAnimation(MoveVelocity);
    }

    private void MovementAnimation(float velocity)
    {
        //MoveVelocity = navAgent.velocity.magnitude;
        animator.SetFloat("MoveVelocity", velocity);
    }
    public void ContinuePatrol()
    {
        if (!navAgent.isActiveAndEnabled)
            return;
        navAgent.isStopped = false;
        if (!navAgent.pathPending && navAgent.remainingDistance < 0.1f)
            GotoNextWayPoint();
    }

    public void Stop()
    {
        if (!navAgent.isActiveAndEnabled)
            return;
        navAgent.SetDestination(transform.position);
        MoveVelocity = navAgent.velocity.magnitude;
    }


    public void GotoNextWayPoint()
    {
        // Returns if no points have been set up
        if (patrolPoints.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        navAgent.destination = patrolPoints[currentPatrolPoint].position;
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Count;
    }
    public void GoToPosition(Vector3 position)
    {
        if (!navAgent.isActiveAndEnabled)
            return;

        navAgent.isStopped = false;
        navAgent.destination = position;
    }
    public void ClearNavAgentPath()
    {
        navAgent.ResetPath();
    }
    public void ActivateNavAgent()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.enabled = true;
    }
}
