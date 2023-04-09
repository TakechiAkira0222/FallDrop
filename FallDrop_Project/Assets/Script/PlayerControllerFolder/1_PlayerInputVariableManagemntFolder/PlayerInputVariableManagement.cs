using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

namespace Takechi.PlayerSpace.InputVariable
{
    public partial class PlayerInputVariableManagement : MonoBehaviour
    {
        private Vector2 mousePostion = Vector2.zero;
        private Vector2 movementAxis = Vector2.zero;

        private void OnMousePostion(InputValue value)
        {
            mousePostion = value.Get<Vector2>();
            //Debug.Log(value.Get<Vector2>());

            MovingMouseAction();
        }

        private void OnMovementAxis(InputValue value)
        {
            movementAxis = value.Get<Vector2>();
            //Debug.Log(value.Get<Vector2>());

            if ( movementAxis != Vector2.zero)
            {
                OnMoveingAction();
            }
            else
            {
                OffMoveingAction();
            }
        }
    }
}