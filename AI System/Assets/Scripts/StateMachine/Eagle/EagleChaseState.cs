using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EagleChaseState : ChaseState
{
    private GameObject eagleBody;
    private float hoverHeight = 1.2f;
    private float elevationSpeed = 1.0f;

    public EagleChaseState(GameObject gameObject, GameObject target) : base(gameObject, target)
    {

    }

    public override void EnterState()
    {
        // Additional initialization if needed
        agent = _gameObject.GetComponent<NavMeshAgent>();
        eagleBody = _gameObject.transform.GetChild(0).gameObject;

    }

    public override void UpdateState()
    {
        // Logic for idle state
        agent.SetDestination(target.transform.position);
        float distance = Vector3.Distance(_gameObject.transform.position, target.transform.position);

        if (eagleBody.transform.position.y > hoverHeight)
        {
            eagleBody.transform.position = new Vector3(eagleBody.transform.position.x, eagleBody.transform.position.y - (Time.deltaTime * elevationSpeed), eagleBody.transform.position.z);
        }
        

        if (distance <= killDistance)
        {
            GameObject.Destroy(target);
            StateMachine stateMachine = _gameObject.GetComponent<StateMachine>();
            stateMachine.ChangeState(new EagleIdleState(_gameObject));
            Debug.Log("Kill");

        }
        else if (distance > cancelDistance)
        {
            StateMachine stateMachine = _gameObject.GetComponent<StateMachine>();
            stateMachine.ChangeState(new EagleMoveState(_gameObject));
        }

    }
}
