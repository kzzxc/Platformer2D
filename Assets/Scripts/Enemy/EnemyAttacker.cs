using UnityEngine;

namespace Enemy
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] private float _damage = 5;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out PlayerScripts.Player player) && _damage > 0)
            {
                player.GetComponent<Health>().TakeDamage(_damage);
            }
        }
    }
}