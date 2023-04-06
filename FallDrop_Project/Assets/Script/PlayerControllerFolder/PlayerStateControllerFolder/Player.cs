using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Takechi.PlayerSpace
{
    public enum Event : int
    {
        standing,
        jumping,
        dead,
    }

    public partial class Player : MonoBehaviour
    {
        private StateMachine<Player> stateMachine;

        private void Start()
        {
            stateMachine = new StateMachine<Player>(this);
            stateMachine.AddTransition<StateStanding, StateJumping>((int)Event.jumping);
            stateMachine.AddAnyTransition<StateDead>((int)Event.dead);
            stateMachine.AddAnyTransition<StateStanding>((int)Event.standing);

            stateMachine.Start<StateStanding>();
        }

        private void Update()
        {
            if (isGrounded)
            {
                if (Keyboard.current.spaceKey.isPressed)
                {
                    stateMachine.Dispatch((int)Event.jumping);
                }
            }

            stateMachine.Update();
        }

        private void FixedUpdate()
        {
            if (Keyboard.current.shiftKey.isPressed && stateMachine.CurrentState is StateStanding)
            {
                if (Keyboard.current.dKey.isPressed)
                {
                    MovingForwardDash();
                }
                if (Keyboard.current.aKey.isPressed)
                {
                    MovingBackDash();
                }
            }
            else
            {
                if (Keyboard.current.dKey.isPressed)
                {
                    MovingForward();
                }
                if (Keyboard.current.aKey.isPressed)
                {
                    MovingBack();
                }
            }

            stateMachine.FixedUpdate();
        }

        private void OnCollisionEnter(Collision collision)
        {
           
        }
    }
}
