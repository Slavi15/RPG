using UnityEngine;

public class ElevationExit : MonoBehaviour
{
    
    private const int SORTING_ORDER = 1;

    [SerializeField] private Collider2D[] mountainColliders;
    [SerializeField] private Collider2D[] boundaryColliders;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        foreach (Collider2D mountain in mountainColliders)
        {
            mountain.enabled = true;
        }

        foreach (Collider2D boundary in boundaryColliders)
        {
            boundary.enabled = false;
        }

        collision.gameObject.GetComponentInParent<SpriteRenderer>().sortingOrder = SORTING_ORDER;
    }
    
}
