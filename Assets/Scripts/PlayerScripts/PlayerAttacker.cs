using UnityEngine;

namespace PlayerScripts
{
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _bulletForce = 20f;

        private void OnFire()
        {
            Shoot();
        }

        private void Shoot()
        {
            Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            Vector2 bulletDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
            rb.AddForce(bulletDirection * _bulletForce, ForceMode2D.Impulse);
        }
    }
}