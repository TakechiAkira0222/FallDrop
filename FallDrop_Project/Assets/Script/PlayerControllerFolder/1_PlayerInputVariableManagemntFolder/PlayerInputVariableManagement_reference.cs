using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Takechi.PlayerSpace.InputVariable
{
    public partial class PlayerInputVariableManagement : MonoBehaviour
    {
        public Action OnMoveingAction = delegate { };
        public Action OffMoveingAction = delegate { };
        public Action MovingMouseAction = delegate { };
    }
}
