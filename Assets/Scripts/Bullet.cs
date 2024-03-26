using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}