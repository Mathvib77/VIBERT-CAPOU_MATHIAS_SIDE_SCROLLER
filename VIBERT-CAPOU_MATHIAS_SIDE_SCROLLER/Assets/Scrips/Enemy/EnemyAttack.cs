using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Attaque")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 6f;
    [SerializeField] float fireRate = 2f;
    [SerializeField] float firePointOffset = 0.5f;

    private float fireCooldown = 0f;
    private EnemyDetection detection;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        detection = GetComponent<EnemyDetection>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (detection.playerDetected && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate;
        }
    }

    void Shoot()
    {
        Vector2 dir = (detection.playerTransform.position - transform.position).normalized;

        Vector2 firePos = (Vector2)transform.position + dir * firePointOffset;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(
            bulletPrefab, firePos, Quaternion.Euler(0, 0, angle)
        );

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = dir * bulletSpeed;

        Destroy(bullet, 4f);
    }
}