using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.CharacterSpace.ReferenceVariable
{
    public partial class CharacterReferenceVariableManagement : MonoBehaviour
    {
        public GameObject GetMyAvater => addresManagement.myAvater;
        public Rigidbody  GetMyRigidbody => addresManagement.myRigidbody;
        public Camera     GetMyCamera => addresManagement.myCamera;
    }
}
