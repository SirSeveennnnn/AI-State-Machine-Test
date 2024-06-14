using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected IState _currentState;

    protected virtual void Start()
    {
        // Initialize with starting state
        _currentState = new IdleState(gameObject);
        _currentState.EnterState();
    }

    protected void Update()
    {
        // Update the current state
        _currentState.UpdateState();
    }

    public void ChangeState(IState newState)
    {
        // Exit current state
        _currentState.ExitState();

        // Change to new state
        _currentState = newState;
        _currentState.EnterState();
    }

}