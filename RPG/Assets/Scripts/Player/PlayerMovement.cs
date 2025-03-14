using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Vector2 movementInput = Vector2.zero;

    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    void Update()
    {
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");

        movementInput = movementInput.normalized;
    }

    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", Mathf.Abs(movementInput.x));
        animator.SetFloat("Vertical", Mathf.Abs(movementInput.y));

        rb.linearVelocity = movementInput * speed;
    }
}
