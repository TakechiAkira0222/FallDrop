using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.CharacterSpace.WeaponController
{
    public partial class CharacterWeaponController : MonoBehaviour
    {
        [SerializeField] private CharacterAddresManagement _characterAddresManagement;
        private CharacterAddresManagement addresManagement => _characterAddresManagement;
    }
}
