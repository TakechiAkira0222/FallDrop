using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using State = StateMachine<Takechi.CharacterSpace.WeaponController.CharacterWeaponController>.State;

namespace Takechi.CharacterSpace.WeaponController
{
    public partial class CharacterWeaponController : MonoBehaviour
    {
        private class StateRotationTheStop : State
        {
            protected override void OnEnter(State prevState)
            {
                Debug.Log("");
            }

            protected override void OnUpdate()
            {

            }
        }

        private class StateRotationTheRight : State
        {
            CharacterAddresManagement ad => Owner.addresManagement;
            GameObject weapon => ad.myWeapon;
            protected override void OnEnter(State prevState)
            {
                Debug.Log("");
            }

            protected override void OnUpdate()
            {
                weapon.transform.localEulerAngles -= Vector3.up * Time.deltaTime * 100;
            }
        }

        private class StateRotationTheLeft : State
        {
            CharacterAddresManagement ad => Owner.addresManagement;
            GameObject weapon => ad.myWeapon;

            protected override void OnEnter(State prevState)
            {
                Debug.Log("");
            }

            protected override void OnUpdate()
            {
                weapon.transform.localEulerAngles += Vector3.up * Time.deltaTime * 100;
            }
        }
    }
}