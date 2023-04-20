using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.CharacterSpace.StatusVariable
{
    public partial class CharacterStatusVariableManagement : MonoBehaviour
    {
        private void Awake()
        {
            initializationStatus();
        }

        private void initializationStatus()
        {
            SetHp = myParameter.GetMaxHp;
            SetAttackPower  = myParameter.GetAttackPower;
            SetDefensePower = myParameter.GetDefensePower;
            SetJumpingMoveSpeed = myParameter.GetJumpingMoveSpeed;
            SetMoveSpeed   = myParameter.GetMoveSpeed;
            SetJumpPower   = myParameter.GetJumpPower;
            SetDashSpeed   = myParameter.GetDashSpeed;
            SetWeaponRoationSpeed = myParameter.GetWeaponRotationSpeed;
        }
    }
}