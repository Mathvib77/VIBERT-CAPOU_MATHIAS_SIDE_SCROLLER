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
        Collider2D hit = Physics2D.OverlapCircle(
            transform.position, detectionRange, playerLayer
        );

        if (hit != null)
        {
            playerDetected = true;
            playerTransform = hit.transform;
        }
        else
        {
            playerDetected = false;
            playerTransform = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}