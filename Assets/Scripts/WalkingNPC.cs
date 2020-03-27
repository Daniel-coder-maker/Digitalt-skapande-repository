using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WalkingNPC : MonoBehaviour
{
    public List<NPCWaypoint> Waypoints = new List<NPCWaypoint>();

    [NonSerialized] public int Index = 0;
    private NavMeshAgent NavAgent;

    private void Awake()
    {
        NavAgent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (Index >= Waypoints.Count) Index = 0;
        NavAgent.SetDestination(Waypoints[Index].transform.position);
        if (Vector3.Distance(transform.position, Waypoints[Index].transform.position) < Waypoints[Index].radius) Index++;
    }
}
