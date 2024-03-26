using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float bulletForce = 20f;

        private void OnFire()
        {
            Shoot();
        }

        private void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            Vector2 bulletDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
            rb.AddForce(bulletDirection * bulletForce, ForceMode2D.Impulse);
        }
    }
}