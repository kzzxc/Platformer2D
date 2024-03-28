using Coins;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(Health))]
    public class Player : MonoBehaviour
    {
        private Health _health;

        private void Start()
        {
            _health = GetComponent<Health>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out MedPack medPack))
            {
                _health.RestoreHealth(medPack.HealthValue);
                Destroy(medPack.gameObject);
            }

            if (col.TryGetComponent(out Coin coin))
            {
                Destroy(coin.gameObject);
            }
        }
    }
}