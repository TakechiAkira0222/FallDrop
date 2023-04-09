using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using State = StateMachine<Takechi.CharacterSpace.StateController.CharacterStateController>.State;

namespace Takechi.CharacterSpace.StateController
{
    public partial class CharacterStateController : MonoBehaviour
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