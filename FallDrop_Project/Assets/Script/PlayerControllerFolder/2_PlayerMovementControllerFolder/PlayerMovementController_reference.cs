using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.PlayerSpace.MovementController
{
    public partial class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private PlayerAddresManagement _playerAddresManagement;

        private PlayerAddresManagement addresManagement => _playerAddresManagement;
    }
}
