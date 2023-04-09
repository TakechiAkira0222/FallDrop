using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Takechi.PlayerSpace.StateController
{
    public enum Event : int
    {
        standing,
        dead,
    }

    public partial class PlayerStateController : MonoBehaviour
    {
        private StateMachine<PlayerStateController> stateMachine;

        private void Start()
        {
            stateMachine = new StateMachine<PlayerStateController>(this);
            stateMachine.AddAnyTransition<StateDead>((int)Event.dead);
            stateMachine.AddAnyTransition<StateStanding>((int)Event.standing);

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
