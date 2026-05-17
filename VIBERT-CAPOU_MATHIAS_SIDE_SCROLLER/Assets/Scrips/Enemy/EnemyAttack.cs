using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Attaque")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletSpeed = 6f;
    [SerializeField] float fireRate = 2f;

    private float fireCooldown = 0f;
    private EnemyDetection detection;

    void Start()
    {
        detection = GetComponent<EnemyDetection>();
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
        Vector2 dir = (detection.playerTransform.position - firePoint.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(
            bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, angle)
        );

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = dir * bulletSpeed;

        Destroy(bullet, 4f);
    }
}