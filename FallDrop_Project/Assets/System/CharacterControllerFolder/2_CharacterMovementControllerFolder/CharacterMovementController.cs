using System.Collections;
using System.Collections.Generic;
using Takechi.CharacterSpace.InputVariable;
using UnityEngine;

namespace Takechi.CharacterSpace.MovementController
{
    public enum Event : int
    {
        standing,
        moving,
        jumping,
        dead,
    }

    public partial class CharacterMovementController : MonoBehaviour
    {
        private StateMachine<CharacterMovementController> stateMachine;
        private CharacterInputVariableManagement inputVariableManagement => addresManagement.GetMyInputVariableManagement;

        private void OnEnable()
        {
            inputVariableManagement.OnMoveingAction  += () =>
            {
                if (stateMachine.CurrentState is StateMovement) return;
                stateMachine.Dispatch((int)Event.moving);
            };

            inputVariableManagement.OffMoveingAction += () =>
            {
                stateMachine.Dispatch((int)Event.standing);
            };

            Debug.Log("addresManagement.myInputVariableManagement.OnMoveingAction function to add. ");
            Debug.Log("addresManagement.myInputVariableManagement.OffMoveingAction function to add. ");
        }

        private void OnDisable()
        {
            inputVariableManagement.OnMoveingAction -= () =>
            {
                if (stateMachine.CurrentState is StateMovement) return;
                stateMachine.Dispatch((int)Event.moving);
            };

            inputVariableManagement.OffMoveingAction -= () =>
            {
                stateMachine.Dispatch((int)Event.standing);
            };

            Debug.Log("addresManagement.myInputVariableManagement.OnMoveingAction function to remove. ");
            Debug.Log("addresManagement.myInputVariableManagement.OffMoveingAction function to remove. ");
        }

        private void Start()
        {
            stateMachine = new StateMachine<CharacterMovementController>(this);
            stateMachine.AddAnyTransition<StateStanding>((int)Event.standing);
            stateMachine.AddTransition<StateStanding, StateMovement>((int)Event.moving);
            stateMachine.Start<StateStanding>();
        }

        private void Update()
        {
            stateMachine.Update();
        }

        private void FixedUpdate()
        {
            stateMachine.FixedUpdate();
        }

        private void OnCollisionEnter(Collision collision)
        {
           
        }
    }
}
