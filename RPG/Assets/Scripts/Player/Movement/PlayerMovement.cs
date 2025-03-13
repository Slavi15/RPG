using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Vector2 movementInput = Vector2.zero;

    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");

        movementInput = movementInput.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movementInput * speed;
    }
}
