using System.Collections;
using System.Collections.Generic;
using Takechi.CharacterSpace.ReferenceVariable;
using Unity.VisualScripting;
using UnityEngine;
using State = StateMachine<Takechi.CharacterSpace.MovementController.CharacterMovementController>.State;

namespace Takechi.CharacterSpace.MovementController
{
    public partial class CharacterMovementController : MonoBehaviour
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
            private CharacterAddresManagement ad => Owner.addresManagement;
            private Rigidbody myRb =>   ad.GetMyReferenceVariableManagement.GetMyRigidbody;
            private float jumpPower =>  ad.GetMyStatusVariableManagement.GetJumpPower;
            private bool  isGrounded => ad.GetMyStatusVariableManagement.GetIsGrounded;

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
            private CharacterAddresManagement ad => Owner.addresManagement;
            private CharacterReferenceVariableManagement refValue => ad.GetMyReferenceVariableManagement;
            private Vector2    axis => ad.GetMyInputVariableManagement.GetMovementAxis;
            private Camera     myCamera => refValue.GetMyCamera;
            private GameObject myBody   => refValue.GetMyBody;
            private Rigidbody  myRb => refValue.GetMyRigidbody;
            private float speed => ad.GetMyStatusVariableManagement.GetMoveSpeed;

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
                     new Vector3( myBody.transform.eulerAngles.x,
                                  myCamera.transform.eulerAngles.y,
                                  myBody.transform.eulerAngles.z);

                myBody.transform.eulerAngles = tagetAngles;
                     Vector3.Lerp( myBody.transform.eulerAngles, tagetAngles, Time.deltaTime);
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