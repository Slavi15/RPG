using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float speed = 2.5f;
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    private Transform player;
    private EnemyState enemyState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeState(EnemyState.Idle);
    }

    void FixedUpdate()
    {
        if (enemyState != EnemyState.Chasing) return;

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
        
        ChangeState(EnemyState.Chasing);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        rb.linearVelocity = Vector2.zero;
        ChangeState(EnemyState.Idle);
    }

    private void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.Idle)
        {
            animator.SetBool("IsIdle", false);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            animator.SetBool("IsChasing", false);
        }

        enemyState = newState;

        if (enemyState == EnemyState.Idle)
        {
            animator.SetBool("IsIdle", true);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            animator.SetBool("IsChasing", true);
        }
    }
}
