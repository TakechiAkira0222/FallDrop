using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Takechi.ExternalData;
using UnityEngine;
using UnityEngine.InputSystem;
using static Takechi.PlayerSpace.CameraController.PlayerCameraController;

namespace Takechi.PlayerSpace.CameraController
{
    public partial class PlayerCameraController : ExternalDataManagement
    {
        private StateMachine<PlayerCameraController> stateMachine;

        private enum Event : int
        {
            stopped,
            lerpTracking,
            tracTking,
        }

        private void Awake()
        {
            controlsSettingData = LoadData(controlsSettingData, "SensityvityData");
            SetXSensityvity = controlsSettingData.xSensityvity;
            SetYSensityvity = controlsSettingData.ySensityvity;
        }

        private void OnEnable()
        {
            ResetCameraRot();
        }

        private void OnDisable()
        {

        }

        private void Start()
        {
            stateMachine = new StateMachine<PlayerCameraController>(this);
            stateMachine.AddAnyTransition<StateLerpTracking>((int)Event.lerpTracking);
            stateMachine.AddAnyTransition<StateStopped>((int)Event.stopped);

            stateMachine.Start<StateUsertoUsingCamera>();
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