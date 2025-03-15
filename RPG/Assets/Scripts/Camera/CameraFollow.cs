using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    [Range(0.1f, 1f)]
    [SerializeField]
    private float smoothFactor = 0.1f;

    [SerializeField] private Vector3 minValues;
    [SerializeField] private Vector3 maxValues;

    private Vector3 currentVelocity;

    void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 targetPosition = player.position + offset;

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z)
        );

        transform.position = Vector3.SmoothDamp(transform.position, boundPosition, ref currentVelocity, smoothFactor);
    }
}
