using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Takechi.CharacterSpace.InputVariable
{
    public partial class CharacterInputVariableManagement : MonoBehaviour
    {
        public Action OnMoveingAction   = delegate { };
        public Action OffMoveingAction  = delegate { };
        public Action MovingMouseAction = delegate { };

        public Action OnRotationTheLeftAction = delegate { };
        public Action OnRotationTheRightAction = delegate { };
        public Action OnRotationTheStopAction = delegate { };
    }
}
