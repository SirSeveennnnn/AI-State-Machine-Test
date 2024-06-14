using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleStateMachine : StateMachine
{
    [SerializeField] private GameObject target;
    public Dictionary<AnimalType, Interaction> EagleInteractions = new Dictionary<AnimalType, Interaction>();

    protected override void Start()
    {
        EagleInteractions.Add(AnimalType.Boar, Interaction.Chase);

        // Initialize with starting state
        _currentState = new EagleMoveState(gameObject);
        _currentState.EnterState();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (target != null)
        {
            return;
        }
    
        if (other.CompareTag("Animal"))
        {
            Interaction action = EagleInteractions[other.GetComponent<Entity>().animalType];

            switch (action)
            {
                case Interaction.Chase:
                    Debug.Log("Chase");
                    ChangeState(new EagleChaseState(gameObject, other.gameObject));
                    //Chase State
                    break;
                case Interaction.Flee:
                    Debug.Log("Flee");
                    //Flee  State
                    break;
                default:
                    break;
            }
        }
    }
}
