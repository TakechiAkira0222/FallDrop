using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.PlayerSpace.StateController
{
    public partial class PlayerStateController : MonoBehaviour
    {
        [SerializeField] private PlayerAddresManagement _playerAddresManagement;
        private PlayerAddresManagement addresManagement => _playerAddresManagement;
    }
}
