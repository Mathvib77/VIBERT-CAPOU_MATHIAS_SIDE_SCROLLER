using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public void TakeHit()
    {
        Destroy(gameObject);
    }
}
