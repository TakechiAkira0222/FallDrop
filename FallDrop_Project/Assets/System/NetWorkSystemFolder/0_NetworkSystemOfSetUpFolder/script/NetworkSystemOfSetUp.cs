using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.NetworkSystem.setup
{
    public class NetworkSystemOfSetUp : MonoBehaviour
    {
        private void Awake()
        {
           DontDestroyOnLoad(this);
        }
    }
}
