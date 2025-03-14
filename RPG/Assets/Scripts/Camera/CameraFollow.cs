using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    [Range(0.1f, 1f)]
    [SerializeField]
    private float smoothFactor = 0.1f;

    private Vector3 currentVelocity;

    void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 newPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVelocity, smoothFactor);
    }
}
