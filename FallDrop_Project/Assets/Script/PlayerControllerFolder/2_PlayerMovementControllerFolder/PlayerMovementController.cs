using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.PlayerSpace.MovementController
{
    public enum Event : int
    {
        standing,
        moving,
        jumping,
        dead,
    }

    public partial class PlayerMovementController : MonoBehaviour
    {
        private StateMachine<PlayerMovementController> stateMachine;

        private void OnEnable()
        {
            addresManagement.myInputVariableManagement.OnMoveingAction  += () =>
            {
                if (stateMachine.CurrentState is StateMovement) return;
                stateMachine.Dispatch((int)Event.moving);
            };

            addresManagement.myInputVariableManagement.OffMoveingAction += () =>
            {
                stateMachine.Dispatch((int)Event.standing);
            };

            Debug.Log("addresManagement.myInputVariableManagement.OnMoveingAction function to add. ");
            Debug.Log("addresManagement.myInputVariableManagement.OffMoveingAction function to add. ");
        }

        private void OnDisable()
        {
            addresManagement.myInputVariableManagement.OnMoveingAction -= () =>
            {
                if (stateMachine.CurrentState is StateMovement) return;
                stateMachine.Dispatch((int)Event.moving);
            };

            addresManagement.myInputVariableManagement.OffMoveingAction -= () =>
            {
                stateMachine.Dispatch((int)Event.standing);
            };

            Debug.Log("addresManagement.myInputVariableManagement.OnMoveingAction function to remove. ");
            Debug.Log("addresManagement.myInputVariableManagement.OffMoveingAction function to remove. ");
        }

        private void Start()
        {
            stateMachine = new StateMachine<PlayerMovementController>(this);
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
