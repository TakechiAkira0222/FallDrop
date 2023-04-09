using System.Collections;
using System.Collections.Generic;
using Takechi.ExternalData;
using UnityEngine;

namespace Takechi.PlayerSpace.CameraController
{
    public partial class PlayerCameraController : ExternalDataManagement
    {
        #region ResetFinction
        public void ResetCameraRot() => addresManagement.myCamera.transform.localRotation = Quaternion.identity; 

        #endregion

        #region RecursiveFunction 
        /// <summary>
        /// ClampRotation
        /// </summary>
        /// <param name="q"></param>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        /// <returns>Å@êßå¿ÇÃÇ©Ç©Ç¡ÇΩÇSéüå≥êîÇÅAÇ©Ç¶ÇµÇ‹Ç∑ÅB</returns>
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