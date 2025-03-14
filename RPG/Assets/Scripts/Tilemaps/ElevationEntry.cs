using UnityEngine;

public class ElevationEntry : MonoBehaviour
{
    
    private const int SORTING_ORDER = 15;

    [SerializeField] private Collider2D[] mountainColliders;
    [SerializeField] private Collider2D[] boundaryColliders;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        foreach (Collider2D mountain in mountainColliders)
        {
            mountain.enabled = false;
        }

        foreach (Collider2D boundary in boundaryColliders)
        {
            boundary.enabled = true;
        }

        collision.gameObject.GetComponentInParent<SpriteRenderer>().sortingOrder = SORTING_ORDER;
    }
    
}
