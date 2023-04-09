using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Takechi.CharacterSpace.InputVariable
{
    [RequireComponent(typeof(PlayerInput))]
    public partial class CharacterInputVariableManagement : MonoBehaviour
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