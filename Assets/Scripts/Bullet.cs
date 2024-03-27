using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}