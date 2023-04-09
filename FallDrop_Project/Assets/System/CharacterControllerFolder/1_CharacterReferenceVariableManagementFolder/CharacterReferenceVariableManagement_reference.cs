using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace Takechi.CharacterSpace.ReferenceVariable
{
    public partial class CharacterReferenceVariableManagement : MonoBehaviour
    {
        [SerializeField] private CharacterAddresManagement _characterAddresManagement;
        private CharacterAddresManagement addresManagement => _characterAddresManagement;

    }
}
