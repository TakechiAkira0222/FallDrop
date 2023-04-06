using System.Collections;
using System.Collections.Generic;
using Takechi.PlayerSpace;
using UnityEngine;

namespace Takechi.PlayerSpace {
    public partial class PlayerCameraController : MonoBehaviour
    {
        [SerializeField] private PlayerAddresManagement _playerAddresManagement;
        private PlayerAddresManagement addresManagement => _playerAddresManagement;
        private GameObject myAvater => addresManagement.myAvater;
        private Camera     myCamera => addresManagement.myCamera;
    }
}
