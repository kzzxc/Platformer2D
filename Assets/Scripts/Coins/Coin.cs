using UnityEngine;

namespace Coins
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player.Player player))
            {
                Destroy(gameObject);
            }
        }
    }
}