using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Takechi.PlayerSpace
{
    public class PlayerAddresManagement : MonoBehaviour
    {
        [SerializeField] private PlayerParameter _playerParameter;
        [SerializeField] private GameObject _avater;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Camera _camera;

        public PlayerParameter myParameter => _playerParameter;
        public GameObject myAvater => _avater;
        public Rigidbody  myRigidbody => _rigidbody;
        public Camera myCamera => _camera;
    }
}
