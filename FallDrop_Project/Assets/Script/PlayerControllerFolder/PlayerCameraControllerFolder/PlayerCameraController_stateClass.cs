using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using State = StateMachine<Takechi.PlayerSpace.PlayerCameraController>.State;

namespace Takechi.PlayerSpace
{
    public partial class PlayerCameraController : MonoBehaviour
    {
        private class StateLerpTracking : State
        {
            protected override void OnEnter(State prevState)
            {
               
            }

            protected override void OnUpdate()
            {
               
            }

            protected override void OnFixedUpdate()
            {
                Vector3 targgetPos =
                   new Vector3(Owner.myAvater.transform.position.x,
                                Owner.myAvater.transform.position.y + 2,
                                Owner.myCamera.transform.position.z);

                Owner.myCamera.transform.position =
                    Vector3.Lerp(Owner.myCamera.transform.position, targgetPos, Time.deltaTime * 10);
            }
        }

        private class StateTracking : State
        {
            protected override void OnEnter(State prevState)
            {

            }

            protected override void OnUpdate()
            {
                
            }

            protected override void OnFixedUpdate()
            {
                Vector3 targgetPos =
                    new Vector3(Owner.myAvater.transform.position.x,
                                 Owner.myCamera.transform.position.y,
                                 Owner.myCamera.transform.position.z);

                Owner.myCamera.transform.position = targgetPos;
            }
        }


        private class StateStopped : State
        {
            protected override void OnEnter(State prevState)
            {

            }

            protected override void OnUpdate()
            {

            }
        }
    }
}
