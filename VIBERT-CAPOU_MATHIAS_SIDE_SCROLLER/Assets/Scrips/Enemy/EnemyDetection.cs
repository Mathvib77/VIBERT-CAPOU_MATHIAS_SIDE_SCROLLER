using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Header("Détection")]
    [SerializeField] float detectionRange = 5f;
    [SerializeField] LayerMask playerLayer;

    [HideInInspector] public bool playerDetected = false;
    [HideInInspector] public Transform playerTransform;

    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position, detectionRange
        );

        playerDetected = false;
        playerTransform = null;

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                playerDetected = true;
                playerTransform = hit.transform;
                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}