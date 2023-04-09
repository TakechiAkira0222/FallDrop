using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Takechi.ExternalData;
using UnityEngine;
using UnityEngine.InputSystem;

using State = StateMachine<Takechi.PlayerSpace.CameraController.PlayerCameraController>.State;

namespace Takechi.PlayerSpace.CameraController
{
    public partial class PlayerCameraController : ExternalDataManagement
    {
        private class StateUsertoUsingCamera : State
        {
            private PlayerAddresManagement ad => Owner.addresManagement;
            private Camera myCamera    => ad.myCamera;
            private Transform myAvater => ad.myAvater.transform;
            private float xSensityvity => Owner.xSensityvity;
            private float ySensityvity => Owner.ySensityvity;
            private float heightM => Owner.heightM;
            private float disToPlayerM => Owner.distanceToPlayerM;
            private float slideDisM => Owner.slideDistanceM;

            protected override void OnUpdate()
            {
                UsingCameraControllProcess(Mouse.current.delta.ReadValue().x, Mouse.current.delta.ReadValue().y);
            }

            private void UsingCameraControllProcess(float mouseX, float mouseY)
            {
                var rotX = mouseX * xSensityvity;
                var rotY = mouseY * ySensityvity;

                var lookAt = myAvater.position + Vector3.up * heightM;

                // 回転
                myCamera.transform.RotateAround(lookAt, Vector3.up, rotX);

                // 角度制限
                myCamera.transform.localRotation =
                  Owner.ClampRotation(myCamera.transform.localRotation, limitedToCamera.minX, limitedToCamera.maxX);

                myCamera.transform.RotateAround(lookAt, myCamera.transform.right, -rotY);

                // カメラとプレイヤーとの間の距離を調整
                myCamera.transform.position = lookAt - myCamera.transform.forward * disToPlayerM;

                // 注視点の設定
                myCamera.transform.LookAt(lookAt);

                // カメラを横にずらして中央を開ける
                myCamera.transform.position = myCamera.transform.position + myCamera.transform.right * slideDisM;
            }
        }

        private class StateLerpTracking : State
        {
            private PlayerAddresManagement ad => Owner.addresManagement;
            private GameObject myAvater => ad.myAvater;
            private Camera myCamera => ad.myCamera;
            protected override void OnEnter(State prevState)
            {
               
            }

            protected override void OnUpdate()
            {
               
            }

            protected override void OnFixedUpdate()
            {
                Vector3 targgetPos =
                   new Vector3( myAvater.transform.position.x,
                                myAvater.transform.position.y + 2,
                                myAvater.transform.position.z - 4);

                myCamera.transform.position =
                    Vector3.Lerp( myCamera.transform.position, targgetPos, Time.deltaTime * 10);
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
