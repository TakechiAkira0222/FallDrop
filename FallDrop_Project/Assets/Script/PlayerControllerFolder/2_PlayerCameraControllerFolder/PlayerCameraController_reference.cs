using System.Collections;
using System.Collections.Generic;
using System.Data;
using Takechi.ExternalData;
using Takechi.PlayerSpace;
using UnityEngine;

namespace Takechi.PlayerSpace.CameraController
{
    public partial class PlayerCameraController : ExternalDataManagement
    {
        [SerializeField] private PlayerAddresManagement _playerAddresManagement;
        private PlayerAddresManagement addresManagement => _playerAddresManagement;

        [SerializeField, Tooltip("カメラとプレイヤーとの距離[m]")]
        private float distanceToPlayerM = 2f;     
        [SerializeField, Tooltip("カメラを横にスライドさせる；プラスの時右へ，マイナスの時左へ[m]")]
        private float slideDistanceM = 0f;       
        [SerializeField, Tooltip("注視点の高さ[m]")]
        private float heightM = 1.2f;
        [SerializeField,Tooltip("感度")] 
        private float xSensityvity, ySensityvity = 1f;

        private ControlsSettingData controlsSettingData = new ControlsSettingData();

        private struct limitedToCamera
        {
            public const float minX = -35f;
            public const float maxX = 40f;
        }

        public class ControlsSettingData
        {
            public float xSensityvity = 0.3f;
            public float ySensityvity = 0.3f;
        }

        #region set vtariable
        private float SetXSensityvity { set => xSensityvity = value; }
        private float SetYSensityvity { set => ySensityvity = value; }

        #endregion
    }
}
