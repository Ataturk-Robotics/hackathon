using UnityEngine;
using UnityEngine.UI;


public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Image background;
    public float parallaxOffset = -1.05f;
    public float backgroundZ;
    public Vector3 backgroundOffset;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Vector3 parallaxPos = smoothedPosition * parallaxOffset;
        // parallaxPos.z = background.transform.position.z;
        parallaxPos.z = backgroundZ;
        background.transform.position = parallaxPos + backgroundOffset;
    }

}
