using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    
}
public class MonsterAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private Transform goal;

    [SerializeField] private float destinationThreshold = 0.5f;

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (goal != null && agent.isOnNavMesh)
            agent.SetDestination(goal.position);

        if (IsDestinationReached())
        {
            Destroy(this.gameObject);
        }
    }

    private bool IsDestinationReached()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= destinationThreshold)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void SetGoal(Transform goal)
    {
        this.goal = goal;
    }

    public bool IsMove()
    {
        if (agent.velocity != Vector3.zero)
            return true;
        
        return false;
    }
}
