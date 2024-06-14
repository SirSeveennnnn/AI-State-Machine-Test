using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    protected readonly GameObject _gameObject;
    protected float maxWaitTime = 5;
    protected float minWaitTime = 3;
    protected float waitTime;
    protected float currentTime = 0;

    public IdleState(GameObject gameObject)
    {
        _gameObject = gameObject;
        
    }

    public virtual void EnterState()
    {
        
        // Additional initialization if needed
        waitTime = Random.Range(minWaitTime, maxWaitTime);
        
    }

    public virtual void UpdateState()
    {
        // Logic for idle state
        currentTime += Time.deltaTime;
        if (currentTime > waitTime)
        {
            StateMachine stateMachine = _gameObject.GetComponent<StateMachine>();
            stateMachine.ChangeState(new MoveState(_gameObject));
        }

    }

    public void ExitState()
    {
     
        // Cleanup if needed
    }
}