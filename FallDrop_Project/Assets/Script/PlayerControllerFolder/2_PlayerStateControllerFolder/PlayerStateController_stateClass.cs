using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using State = StateMachine<Takechi.PlayerSpace.StateController.PlayerStateController>.State;

namespace Takechi.PlayerSpace.StateController
{
    public partial class PlayerStateController : MonoBehaviour
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

        private class StateDead : State
        {
            protected override void OnEnter(State prevState)
            {
               
            }
        }
    }
}