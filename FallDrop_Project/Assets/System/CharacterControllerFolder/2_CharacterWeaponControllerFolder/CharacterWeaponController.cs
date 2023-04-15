using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Takechi.CharacterSpace.InputVariable;
using UnityEngine;

namespace Takechi.CharacterSpace.WeaponController
{
    public partial class CharacterWeaponController : MonoBehaviour
    {
        private StateMachine<CharacterWeaponController> stateMachine;
        private CharacterInputVariableManagement inputVariableManagement => addresManagement.GetMyInputVariableManagement;

        enum Event : int 
        {
            rotationTheStop,
            rotationTheRight,
            rotationTheLeft,
        }

        private void OnEnable()
        {
            inputVariableManagement.OnRotationTheStopAction += () =>
            {
                if (stateMachine.CurrentState is StateRotationTheStop) return;
                stateMachine.Dispatch((int)Event.rotationTheStop);
            };

            inputVariableManagement.OnRotationTheRightAction += () =>
            {
                if (stateMachine.CurrentState is StateRotationTheRight) return;
                stateMachine.Dispatch((int)Event.rotationTheRight);
            };

            inputVariableManagement.OnRotationTheLeftAction += () =>
            {
                if (stateMachine.CurrentState is StateRotationTheLeft) return;
                stateMachine.Dispatch((int)Event.rotationTheLeft);
            };

            Debug.Log("addresManagement.myInputVariableManagement.OnRotationTheStopAction function to add. ");
            Debug.Log("addresManagement.myInputVariableManagement.OnRotationTheRightAction function to add. ");
            Debug.Log("addresManagement.myInputVariableManagement.OnRotationTheLeftAction function to add. ");
        }

        private void OnDisable()
        {
            inputVariableManagement.OnRotationTheStopAction -= () =>
            {
                if (stateMachine.CurrentState is StateRotationTheStop) return;
                stateMachine.Dispatch((int)Event.rotationTheStop);
            };

            inputVariableManagement.OnRotationTheRightAction -= () =>
            {
                if (stateMachine.CurrentState is StateRotationTheRight) return;
                stateMachine.Dispatch((int)Event.rotationTheRight);
            };

            inputVariableManagement.OnRotationTheLeftAction -= () =>
            {
                if (stateMachine.CurrentState is StateRotationTheLeft) return;
                stateMachine.Dispatch((int)Event.rotationTheLeft);
            };

            Debug.Log("addresManagement.myInputVariableManagement.OnRotationTheStopAction function to remove. ");
            Debug.Log("addresManagement.myInputVariableManagement.OnRotationTheRightAction function to remove. ");
            Debug.Log("addresManagement.myInputVariableManagement.OnRotationTheLeftAction function to remove. ");
        }


        private void Start()
        {
            stateMachine = new StateMachine<CharacterWeaponController>(this);
            stateMachine.AddAnyTransition<StateRotationTheStop>((int)Event.rotationTheStop);
            stateMachine.AddAnyTransition<StateRotationTheRight>((int)Event.rotationTheRight);
            stateMachine.AddAnyTransition<StateRotationTheLeft>((int)Event.rotationTheLeft);

            stateMachine.Start<StateRotationTheStop>();

        }
       
        private void Update()
        {
            stateMachine.Update();
        }

        private void FixedUpdate()
        {
            stateMachine.FixedUpdate();
        }
    }
}
