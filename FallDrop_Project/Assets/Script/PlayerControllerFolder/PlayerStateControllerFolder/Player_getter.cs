using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.PlayerSpace
{
    public partial class Player : MonoBehaviour
    {
        [SerializeField] private PlayerAddresManagement _playerAddresManagement;
        private PlayerAddresManagement addresManagement => _playerAddresManagement;
        private PlayerParameter myParameter => addresManagement.myParameter;
        private Rigidbody  myRigidbody => addresManagement.myRigidbody;
        private GameObject myAvater => addresManagement.myAvater;
    }
}
