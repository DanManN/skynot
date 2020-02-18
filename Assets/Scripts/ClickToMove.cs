using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Util;

public class ClickToMove : MonoBehaviour
{

    public Transform goal;

    private UnityEngine.AI.NavMeshAgent agent;
    private bool move;
    private Vector3 hDest;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        move = true;
        agent.destination = goal.position;
        agent.enabled = true;
    }

    void FixedUpdate()
    {
        Vector3 hTrans = transform.position - vert(transform.position.y);
        if ((hDest - hTrans).sqrMagnitude <= pow2(agent.stoppingDistance))
        {
            move = false;
        }

        if (move)
        {
            agent.enabled = true;
            agent.isStopped = false;
        }

    }

    public void Destination(Vector3 d)
    {
        agent.destination = d;
        hDest = d - vert(d.y);
        move = true;
    }
}
