using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.CharacterSpace.InputVariable
{
    public partial class CharacterInputVariableManagement : MonoBehaviour
    {
        public Vector2 GetMousePostion => mousePostion;
        public Vector2 GetMovementAxis => movementAxis;
    }
}
