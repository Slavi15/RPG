using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyDirection : MonoBehaviour
{
    
    [SerializeField] private Transform player;
    private bool isFacingRight;

    void Awake()
    {
        isFacingRight = true;
    }

    void FixedUpdate()
    {
        if ((player.position.x > transform.position.x && !isFacingRight) ||
            (player.position.x < transform.position.x && isFacingRight))
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
