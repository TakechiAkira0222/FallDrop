using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using State = StateMachine<Takechi.PlayerSpace.Player>.State;

namespace Takechi.PlayerSpace
{
    public partial class Player : MonoBehaviour
    {
        private class StateStanding : State
        {
            protected override void OnUpdate()
            {
            }
        }

        private class StateSquatting : State
        {
            protected override void OnUpdate()
            {
            }
        }

        public class StateJumpInSquat : State
        {
            protected override void OnEnter(State prevState)
            {
                if (!Owner.isGrounded) return;
                Owner.myRigidbody.AddForce(Vector3.up * Owner.myParameter.jumpPower / 2, ForceMode.Impulse);
            }

            protected override void OnUpdate()
            {
            }
        }

        public class StateJumping : State
        {
            protected override void OnEnter(State prevState)
            {
                if (!Owner.isGrounded) return;
                Owner.myRigidbody.AddForce(Vector3.up * Owner.myParameter.jumpPower, ForceMode.Impulse);
            }

            protected override void OnUpdate()
            {
            }
        }

        private class StateDead : State
        {
            protected override void OnEnter(State prevState)
            {
                Owner.transform.position = Vector3.up;

                stateMachine.Dispatch((int)Event.standing);
            }
        }
    }
}