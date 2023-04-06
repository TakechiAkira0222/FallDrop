using UnityEngine;

namespace Takechi.PlayerSpace
{
    public partial class Player : MonoBehaviour
    {
        public bool isGrounded
        {
            get
            {
                Ray ray =
                       new Ray(myRigidbody.gameObject.transform.position + new Vector3(0, 0.1f),
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
