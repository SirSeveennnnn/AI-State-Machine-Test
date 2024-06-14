using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleIdleState : IdleState
{
    public EagleIdleState(GameObject gameObject) : base(gameObject)
    {

    }

    public override void UpdateState()
    {
        // Logic for idle state
        currentTime += Time.deltaTime;
        if (currentTime > waitTime)
        {
            StateMachine stateMachine = _gameObject.GetComponent<StateMachine>();
            stateMachine.ChangeState(new EagleMoveState(_gameObject));
        }

    }
}
