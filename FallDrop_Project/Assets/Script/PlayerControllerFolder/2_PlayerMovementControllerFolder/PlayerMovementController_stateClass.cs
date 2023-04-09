using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using State = StateMachine<Takechi.PlayerSpace.MovementController.PlayerMovementController>.State;

namespace Takechi.PlayerSpace.MovementController
{
    public partial class PlayerMovementController : MonoBehaviour
    {
        public class StateStanding : State
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

        public class StateJumping : State
        {
            private PlayerAddresManagement ad => Owner.addresManagement;
            private Rigidbody myRb => ad.myRigidbody;
            private float jumpPower =>  ad.myParameter.jumpPower;
            private bool  isGrounded => ad.myStateVariableManagement.GetIsGrounded;

            protected override void OnEnter(State prevState)
            {
                if (!isGrounded) return;
                myRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }

            protected override void OnUpdate()
            {

            }
        }

        private class StateMovement : State
        {
            private PlayerAddresManagement ad => Owner.addresManagement;
            private Vector2    axis => ad.myInputVariableManagement.GetMovementAxis;
            private Camera     myCamera => ad.myCamera;
            private GameObject myAvater => ad.myAvater;
            private Rigidbody  myRb => ad.myRigidbody;
            private float speed => ad.myParameter.moveSpeed;

            protected override void OnEnter(State prevState)
            {
               
            }

            protected override void OnUpdate()
            {
                RestoreTheAvatarViewpoint();
            }

            protected override void OnFixedUpdate()
            {
                MovementControllProcess(axis, speed);
            }

            private void RestoreTheAvatarViewpoint()
            {
                Vector3 tagetAngles =
                     new Vector3( myAvater.transform.eulerAngles.x,
                                  myCamera.transform.eulerAngles.y,
                                  myAvater.transform.eulerAngles.z);

                myAvater.transform.eulerAngles = Vector3.Lerp( myAvater.transform.eulerAngles, tagetAngles, 0.5f);
            }
            private void MovementControllProcess(Vector2 axis, float moveSpeed)
            {
                Vector3 movementVelocity;

                var movementVector =
                      new Vector3(axis.x, 0, axis.y);

                movementVelocity =
                      myCamera.transform.forward * movementVector.z +
                      myCamera.transform.right * movementVector.x;

                movementVelocity.Normalize();

                myRb.velocity =
                    new Vector3(movementVelocity.x * moveSpeed,
                                 myRb.velocity.y,
                                 movementVelocity.z * moveSpeed);
            }
        }
    }
}