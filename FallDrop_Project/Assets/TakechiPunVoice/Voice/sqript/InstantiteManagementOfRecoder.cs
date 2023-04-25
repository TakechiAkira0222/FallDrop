using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace TakechiPunVoice.Management
{
    public class InstantiteManagementOfRecoder : MonoBehaviour
    {
        [SerializeField] private GameObject m_recoderPrefab;

        void Awake()
        {
            setInstantiate();
        }

        void setInstantiate()
        {
            if (GameObject.Find( m_recoderPrefab.name + "(Clone)") != null)
                return;

            Instantiate( m_recoderPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
