using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EagleMoveState : MoveState
{
    private GameObject eagleBody;

    private float targetElevation;
    private float elevationHeight = 3.0f;
    private float elevationSpeed = 1.0f;

    public EagleMoveState(GameObject gameObject) : base(gameObject)
    {

    }

    public override void EnterState()
    {
        eagleBody = _gameObject.transform.GetChild(0).gameObject;
        base.EnterState();

    }

    public override void UpdateState()
    {
        if (eagleBody.transform.position.y < elevationHeight)
        {
            eagleBody.transform.position = new Vector3(eagleBody.transform.position.x, eagleBody.transform.position.y + (Time.deltaTime * elevationSpeed), eagleBody.transform.position.z);
        }

        // Logic for idle state
        if (agent.remainingDistance <= agent.stoppingDistance + 1 && !agent.pathPending)
        {
            // The agent has reached its destination
            StateMachine stateMachine = _gameObject.GetComponent<StateMachine>();
            stateMachine.ChangeState(new EagleMoveState(_gameObject));
        }

    }
}
