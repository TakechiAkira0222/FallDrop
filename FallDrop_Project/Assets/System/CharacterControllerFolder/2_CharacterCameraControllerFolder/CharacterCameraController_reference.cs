using System.Collections;
using System.Collections.Generic;
using System.Data;
using Takechi.ExternalData;
using Takechi.CharacterSpace;
using UnityEngine;

namespace Takechi.CharacterSpace.CameraController
{
    public partial class CharacterCameraController : ExternalDataManagement
    {
        [SerializeField] private CharacterAddresManagement _CharacterAddresManagement;
        private CharacterAddresManagement addresManagement => _CharacterAddresManagement;

        [SerializeField, Tooltip("�J�����ƃv���C���[�Ƃ̋���[m]")]
        private float distanceToCharacterM = 2f;     
        [SerializeField, Tooltip("�J���������ɃX���C�h������G�v���X�̎��E�ցC�}�C�i�X�̎�����[m]")]
        private float slideDistanceM = 0f;       
        [SerializeField, Tooltip("�����_�̍���[m]")]
        private float heightM = 1.2f;
        [SerializeField,Tooltip("���x")] 
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
