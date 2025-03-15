using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    private const int DAMAGE = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-DAMAGE);
    }
}
