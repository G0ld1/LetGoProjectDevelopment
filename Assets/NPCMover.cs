using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMover : MonoBehaviour
{
    public float stoppingDistance = 0.1f;
    private NavMeshAgent agent;
    private System.Action onArrive;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (agent.pathPending || !agent.hasPath)
            return;

        if (!agent.isStopped && agent.remainingDistance <= stoppingDistance)
        {
            agent.isStopped = true;
            onArrive?.Invoke();
            onArrive = null;
        }
    }

    public void MoveTo(Vector3 pos, System.Action onArriveCallback = null)
    {
        agent.isStopped = false;
        agent.SetDestination(pos);
        onArrive = onArriveCallback;
    }

    public bool IsMoving => agent.hasPath && !agent.isStopped;
}
