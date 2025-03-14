using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    
    private bool isFacingRight;

    void Awake()
    {
        isFacingRight = true;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movementInput = new Vector2(horizontal, vertical);

        if (movementInput != Vector2.zero)
        {
            TurnCheck(movementInput);
        }
    }

    private void TurnCheck(Vector2 movementInput)
    {
        if (isFacingRight && movementInput.x < 0)
        {
            Turn(false);
        }
        else if (!isFacingRight && movementInput.x > 0)
        {
            Turn(true);
        }
    }

    private void Turn(bool turnRight)
    {
        isFacingRight = turnRight;
        transform.Rotate(0f, turnRight ? 180f : -180f, 0f);
    }
}
