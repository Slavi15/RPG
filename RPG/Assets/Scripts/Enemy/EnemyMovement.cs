using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float speed = 2.5f;

    private Rigidbody2D rb;
    private Transform player;
    private bool isChasing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isChasing) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (player == null)
        {
            player = collision.transform;
        }
        
        isChasing = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        rb.linearVelocity = Vector2.zero;
        isChasing = false;
    }
}
