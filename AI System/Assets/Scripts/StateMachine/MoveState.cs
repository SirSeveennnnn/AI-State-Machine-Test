using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : IState
{
    protected readonly GameObject _gameObject;
    protected Vector3 targetPosition;
    protected float offset = 10.0f;
    protected NavMeshAgent agent;

    public MoveState(GameObject gameObject)
    {
        _gameObject = gameObject;
    }

    public virtual void EnterState()
    {
        
        //Calculate Origin of Ray
       


        bool validPoint = false;
        while (!validPoint)
        {
            float randomX = _gameObject.transform.position.x + Random.Range(-offset, offset);
            float randomZ = _gameObject.transform.position.z + Random.Range(-offset, offset);
            float originHeight = 10;

            Vector3 originPoint = new Vector3(randomX, originHeight, randomZ);

            RaycastHit hit;
            //Check if valid point
            if (Physics.Raycast(originPoint, Vector3.down, out hit, Mathf.Infinity)) //Modify to check for valid ground (layer mask, distance, etc)
            {
                
                targetPosition = hit.point;
                validPoint = true;
            }
        }

        agent = _gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(targetPosition);
  
    }

    public virtual void UpdateState()
    {
        // Logic for idle state
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            // The agent has reached its destination
            StateMachine stateMachine = _gameObject.GetComponent<StateMachine>();
            stateMachine.ChangeState(new IdleState(_gameObject));
        }

    }

    public virtual void ExitState()
    {
        
        // Cleanup if needed
    }
}
