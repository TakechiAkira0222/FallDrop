using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.PlayerSpace
{
    [CreateAssetMenu(menuName = "MyScriptable/Create PlayerParameter")]
    public class PlayerParameter : ScriptableObject
    {
        public int maxHp = 3;
        public int jumpPower = 10;
        public int moveSpeed = 5;
        public int dashSpeed = 8;
        public int jumpingMoveSpeed = 2;
    }
}