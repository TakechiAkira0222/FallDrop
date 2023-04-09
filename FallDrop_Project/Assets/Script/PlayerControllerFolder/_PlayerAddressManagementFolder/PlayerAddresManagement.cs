using System.Collections;
using System.Collections.Generic;
using Takechi.PlayerSpace.InputVariable;
using Takechi.PlayerSpace.StateVariable;
using Unity.VisualScripting;
using UnityEngine;

namespace Takechi.PlayerSpace
{
    public class PlayerAddresManagement : MonoBehaviour
    {
        [SerializeField] private PlayerParameter _playerParameter;
        [SerializeField] private PlayerInputVariableManagement _playerInputVariableManagement;
        [SerializeField] private PlayerStateVariableManagement _playerStateVariableManagement;

        [SerializeField] private GameObject _avater;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Camera    _camera;

        public PlayerParameter myParameter => _playerParameter;
        public PlayerInputVariableManagement myInputVariableManagement => _playerInputVariableManagement;
        public PlayerStateVariableManagement myStateVariableManagement => _playerStateVariableManagement;
        public GameObject myAvater    => _avater;
        public Rigidbody  myRigidbody => _rigidbody;
        public Camera     myCamera    => _camera;
    }
}
