using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takechi.PlayerSpace.StateVariable
{
    public partial class PlayerStateVariableManagement : MonoBehaviour
    {
        public bool GetIsGrounded
        {
            get
            {
                Ray ray =
                       new Ray(ad.myRigidbody.gameObject.transform.position + new Vector3(0, 0.1f),
                                Vector3.down * 0.3f);

                RaycastHit raycastHit;

                if (Physics.Raycast(ray, out raycastHit, 0.3f))
                {
                    Debug.DrawRay(ray.origin, ray.direction * 0.3f, Color.green);
                    return true;
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * 0.3f, Color.red);
                    return false;
                }
            }
        }
    }
}