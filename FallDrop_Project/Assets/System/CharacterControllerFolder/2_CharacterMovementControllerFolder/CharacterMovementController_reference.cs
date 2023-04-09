using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.CharacterSpace.MovementController
{
    public partial class CharacterMovementController : MonoBehaviour
    {
        [SerializeField] private CharacterAddresManagement _characterAddresManagement;

        private CharacterAddresManagement addresManagement => _characterAddresManagement;
    }
}
