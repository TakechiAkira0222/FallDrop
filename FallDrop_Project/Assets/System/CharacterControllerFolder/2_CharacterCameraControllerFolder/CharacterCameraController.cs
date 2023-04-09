using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Takechi.ExternalData;
using UnityEngine;
using UnityEngine.InputSystem;
using static Takechi.CharacterSpace.CameraController.CharacterCameraController;

namespace Takechi.CharacterSpace.CameraController
{
    public partial class CharacterCameraController : ExternalDataManagement
    {
        private StateMachine<CharacterCameraController> stateMachine;

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
            stateMachine = new StateMachine<CharacterCameraController>(this);
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