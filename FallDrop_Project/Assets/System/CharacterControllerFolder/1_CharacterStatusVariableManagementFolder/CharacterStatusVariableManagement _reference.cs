using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Takechi.CharacterSpace.Parameter;

namespace Takechi.CharacterSpace.StatusVariable
{
    public partial class CharacterStatusVariableManagement : MonoBehaviour
    {
        [SerializeField] private CharacterAddresManagement _characterAddresManagement;
        private CharacterAddresManagement ad => _characterAddresManagement;
        private CharacterParameter myParameter => ad.GetMyParameter;
    }
}