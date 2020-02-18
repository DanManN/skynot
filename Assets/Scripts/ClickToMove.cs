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

    public void setMove(bool canMove)
    {
        move = canMove;
    }

    public bool canMove()
    {
        return move;
    }

    private bool canMove(GameObject go)
    {
        return go.GetComponent<ClickToMove>().canMove();
    }

    public void setDestination(Vector3 d)
    {
        agent.destination = d;
        hDest = d - vert(d.y);
        move = true;
    }

    public Vector3 getDestination()
    {
        return agent.destination;
    }

    private Vector3 getDestination(GameObject go)
    {
        return go.GetComponent<ClickToMove>().getDestination();
    }

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        setDestination(goal.position);
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
            // agent.enabled = true;
            agent.isStopped = false;
        }
        else
        {
            // agent.enabled = false;
            agent.isStopped = true;
        }

    }


    void OnTriggerEnter(Collider coll)
    {
        GameObject other = coll.gameObject;
        // print(collider + ", " + other);
        // print(other.GetComponent<ClickToMove>());
        // if (canMove() && other.CompareTag("Agent"))
            // print(getDestination(other) + ", " + getDestination() + ", " + !canMove(other));
        if (canMove() && other.CompareTag("Agent") && getDestination(other) == getDestination() && !canMove(other))
        {
            move = false;
        }
    }

}
