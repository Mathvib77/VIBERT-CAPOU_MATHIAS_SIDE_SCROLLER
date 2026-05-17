using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackRange = 1f;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] SpriteRenderer spriteRenderer;

    private Vector2 lastAttackPos;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }

    void Attack()
    {
        Vector2 offset = spriteRenderer.flipX ? Vector2.left : Vector2.right;
        Vector2 attackPos = (Vector2)transform.position + offset;

        lastAttackPos = attackPos;

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPos, attackRange, enemyLayer);

        Debug.Log("Position attaque : " + attackPos);
        Debug.Log("Ennemis touchés : " + hits.Length);

        foreach (Collider2D hit in hits)
        {
            Debug.Log("Collider touché : " + hit.gameObject.name + " | Layer : " + hit.gameObject.layer);
            EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
            if (enemy != null) enemy.TakeHit();
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(lastAttackPos, attackRange);
    }
}