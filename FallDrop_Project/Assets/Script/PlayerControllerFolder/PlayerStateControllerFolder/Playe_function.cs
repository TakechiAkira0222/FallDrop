using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Takechi.PlayerSpace
{
    public partial class Player : MonoBehaviour
    {
        public void MovingForward()
        {
            if (isGrounded)
            {
                if (myRigidbody.velocity.magnitude < myParameter.moveSpeed)
                {
                    myRigidbody.AddForce(myAvater.transform.forward, ForceMode.Impulse);
                }
            }
            else
            {
                myRigidbody.AddForce(myAvater.transform.forward * myParameter.jumpingMoveSpeed);
            }
        }

        public void MovingBack()
        {
            if (isGrounded)
            {
                if (myRigidbody.velocity.magnitude < myParameter.moveSpeed)
                {
                    myRigidbody.AddForce((myAvater.transform.forward * -1), ForceMode.Impulse);
                }
            }
            else
            {
                myRigidbody.AddForce((myAvater.transform.forward * -1) * myParameter.jumpingMoveSpeed);
            }
        }

        public void MovingForwardDash()
        {
            if (myRigidbody.velocity.magnitude < myParameter.dashSpeed)
            {
                myRigidbody.AddForce(myAvater.transform.forward, ForceMode.Impulse);
            }
        }
        public void MovingBackDash()
        {
            if (myRigidbody.velocity.magnitude < myParameter.dashSpeed)
            {
                myRigidbody.AddForce((myAvater.transform.forward * -1), ForceMode.Impulse);
            }
        }
    }
}