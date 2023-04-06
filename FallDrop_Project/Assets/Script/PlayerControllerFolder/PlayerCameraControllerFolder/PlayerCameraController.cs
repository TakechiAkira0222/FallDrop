using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.PlayerSpace
{
    public partial class PlayerCameraController : MonoBehaviour
    {
        private StateMachine<PlayerCameraController> stateMachine;

        private enum Event : int
        {
            stopped,
            lerpTracking,
            tracTking,
        }

        private void Start()
        {
            stateMachine = new StateMachine<PlayerCameraController>(this);
            stateMachine.AddAnyTransition<StateLerpTracking>((int)Event.lerpTracking);
            stateMachine.AddAnyTransition<StateStopped>((int)Event.stopped);

            stateMachine.Start<StateLerpTracking>();
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