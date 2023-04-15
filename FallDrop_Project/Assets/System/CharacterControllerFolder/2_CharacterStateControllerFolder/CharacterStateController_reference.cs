using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.CharacterSpace.StateController
{
    public partial class CharacterStateController : MonoBehaviour
    {
        [SerializeField] private CharacterAddresManagement _characterAddresManagement;
        private CharacterAddresManagement addresManagement => _characterAddresManagement;
    }
}
