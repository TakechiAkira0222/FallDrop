using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.CharacterSpace.StateController
{
    public partial class CharacterStateController : MonoBehaviour
    {
        [SerializeField] private CharacterAddresManagement _CharacterAddresManagement;
        private CharacterAddresManagement addresManagement => _CharacterAddresManagement;
    }
}
