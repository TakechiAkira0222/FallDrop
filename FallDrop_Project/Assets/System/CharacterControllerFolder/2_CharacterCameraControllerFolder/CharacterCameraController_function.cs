using System.Collections;
using System.Collections.Generic;
using Takechi.ExternalData;
using UnityEngine;

namespace Takechi.CharacterSpace.CameraController
{
    public partial class CharacterCameraController : ExternalDataManagement
    {
        #region ResetFinction
        public void ResetCameraRot() => addresManagement.GetMyReferenceVariableManagement.GetMyCamera.transform.localRotation = Quaternion.identity; 

        #endregion

        #region RecursiveFunction 
        /// <summary>
        /// ClampRotation
        /// </summary>
        /// <param name="q"></param>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        /// <returns>�@�����̂��������S���������A�������܂��B</returns>
        private Quaternion ClampRotation(Quaternion q, float minX, float maxX)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1f;

            float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

            angleX = Mathf.Clamp(angleX, minX, maxX);

            q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

            return q;
        }
        #endregion
    }
}