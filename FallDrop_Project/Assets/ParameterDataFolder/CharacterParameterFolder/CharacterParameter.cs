using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Takechi.CharacterSpace.Parameter
{
    [CreateAssetMenu(menuName = "MyScriptable/Create CharacterParameter")]
    public class CharacterParameter : ScriptableObject
    {
        [SerializeField] private int   _maxHp = 10;
        [SerializeField] private float _attackPower  = 3;
        [SerializeField] private float _defensePower = 3;
        [SerializeField] private float _jumpPower = 10;
        [SerializeField] private float _moveSpeed = 5;
        [SerializeField] private float _dashSpeed = 8;
        [SerializeField] private float _jumpingMoveSpeed = 2;

        public int   GetMaxHp => _maxHp;
        public float GetAttackPower => _attackPower;
        public float GetDefensePower => _defensePower;
        public float GetJumpPower => _jumpPower;
        public float GetMoveSpeed => _moveSpeed;
        public float GetDashSpeed => _dashSpeed;
        public float GetJumpingMoveSpeed => _jumpingMoveSpeed;
    }
}