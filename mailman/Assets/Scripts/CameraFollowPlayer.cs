using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float followSpeed;

    void LateUpdate()
    { 
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothenedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed); 
        transform.position = smoothenedPosition;
        transform.LookAt(player);
    }
}
