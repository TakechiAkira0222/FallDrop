using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.PlayerSpace.InputVariable
{
    public partial class PlayerInputVariableManagement : MonoBehaviour
    {
        public Vector2 GetMousePostion => mousePostion;
        public Vector2 GetMovementAxis => movementAxis;
    }
}
