using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.CharacterSpace.StatusVariable
{
    public partial class CharacterStatusVariableManagement : MonoBehaviour
    {
        public bool GetIsGrounded
        {
            get
            {
                Ray ray =
                       new Ray(ad.GetMyReferenceVariableManagement.GetMyRigidbody.gameObject.transform.position + new Vector3(0, 0.1f),
                                Vector3.down * 0.3f);

                RaycastHit raycastHit;

                if (Physics.Raycast(ray, out raycastHit, 0.3f))
                {
                    Debug.DrawRay(ray.origin, ray.direction * 0.3f, Color.green);
                    return true;
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * 0.3f, Color.red);
                    return false;
                }
            }
        }

        public int   GetHp => hp;
        public float GetAttackPower => attackPower;
        public float GetDefensePower => defensePower;
        public float GetJumpPower => jumpPower;
        public float GetMoveSpeed => moveSpeed;
        public float GetDashSpeed => dashSpeed;
        public float GetJumpingMoveSpeed => jumpingMoveSpeed;
        public float GetWeaponRoationSpeed => weaponRoationSpeed; 
    }
}