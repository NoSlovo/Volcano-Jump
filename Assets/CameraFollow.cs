using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offsetY = 2f;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        var position = transform.position;
        Vector3 desiredPosition = new Vector3(position.x, player.position.y + offset.y + offsetY,
            position.z);

        Vector3 smoothedPosition = Vector3.Lerp(position, desiredPosition, smoothSpeed);
        position = smoothedPosition;
        transform.position = position;
    }
}