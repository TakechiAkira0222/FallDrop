using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Takechi.CharacterSpace.Parameter;
using Takechi.CharacterSpace.InputVariable;
using Takechi.CharacterSpace.StatusVariable;
using Takechi.CharacterSpace.ReferenceVariable;
using System;

namespace Takechi.CharacterSpace
{
    public class CharacterAddresManagement : MonoBehaviour
    {
        [SerializeField] private CharacterParameter _characterParameter;
        [SerializeField] private CharacterInputVariableManagement     _characterInputVariableManagement;
        [SerializeField] private CharacterStatusVariableManagement    _characterStatusVariableManagement;
        [SerializeField] private CharacterReferenceVariableManagement _characterReferenceVariableManagement;

        [SerializeField] private GameObject _avater;
        [SerializeField] private Rigidbody  _rigidbody;
        [SerializeField] private Camera     _camera;

        public CharacterParameter GetMyParameter => _characterParameter;
        public CharacterInputVariableManagement     GetMyInputVariableManagement  => _characterInputVariableManagement;
        public CharacterStatusVariableManagement    GetMyStatusVariableManagement => _characterStatusVariableManagement;
        public CharacterReferenceVariableManagement GetMyReferenceVariableManagement => _characterReferenceVariableManagement;

        /// <summary>
        /// 非推奨　'CharacterReferenceVariableManagement' を使用します。
        /// </summary>
        public GameObject myAvater    => _avater;
        /// <summary>
        /// 非推奨　'CharacterReferenceVariableManagement' を使用します。
        /// </summary>
        public Rigidbody  myRigidbody => _rigidbody;
        /// <summary>
        /// 非推奨　'CharacterReferenceVariableManagement' を使用します。
        /// </summary>
        public Camera     myCamera    => _camera;
    }
}
