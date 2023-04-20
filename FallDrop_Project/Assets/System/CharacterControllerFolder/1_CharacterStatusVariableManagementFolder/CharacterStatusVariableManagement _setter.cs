using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.CharacterSpace.StatusVariable
{
    public partial class CharacterStatusVariableManagement : MonoBehaviour
    {
        public int   SetHp { set => hp = value; }
        public float SetAttackPower  { set => attackPower = value; }
        public float SetDefensePower { set => defensePower = value; }
        public float SetJumpPower { set => jumpPower = value; }
        public float SetMoveSpeed { set => moveSpeed = value; }
        public float SetDashSpeed { set => dashSpeed = value; }
        public float SetJumpingMoveSpeed { set => jumpingMoveSpeed = value; }
        public float SetWeaponRoationSpeed { set => weaponRoationSpeed = value; }
    }
}