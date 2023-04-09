using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.PlayerSpace.StateVariable
{
    public partial class PlayerStateVariableManagement : MonoBehaviour
    {
        [SerializeField] private PlayerAddresManagement _playerAddresManagement;
        private PlayerAddresManagement ad => _playerAddresManagement;
    }
}