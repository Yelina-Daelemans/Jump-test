using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    public float smoothSpeed = 0.5f;

    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition= Target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition ;  
    }
}
