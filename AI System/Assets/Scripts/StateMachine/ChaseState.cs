using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IState
{
    protected readonly GameObject _gameObject;
    protected GameObject target;

    protected NavMeshAgent agent;

    protected float killDistance = 1.5f;
    protected float cancelDistance = 8.0f;

    public ChaseState(GameObject gameObject, GameObject target)
    {
        _gameObject = gameObject;
        this.target = target;
    }

    public virtual void EnterState()
    {
        // Additional initialization if needed
        agent = _gameObject.GetComponent<NavMeshAgent>();

    }

    public virtual void UpdateState()
    {
        // Logic for idle state
        agent.SetDestination(target.transform.position);
        float distance = Vector3.Distance(_gameObject.transform.position, target.transform.position);

        if (distance <= killDistance)
        {
            GameObject.Destroy(target);
        }
        else if (distance > cancelDistance)
        {
            StateMachine stateMachine = _gameObject.GetComponent<StateMachine>();
            stateMachine.ChangeState(new IdleState(_gameObject));
        }

    }

    public void ExitState()
    {
        // Cleanup if needed

    }
}
