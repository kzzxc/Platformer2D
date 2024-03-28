using System;
using PlayerScripts;
using UnityEngine;


namespace Enemy
{
    public class ChaseArea : MonoBehaviour
    {
        public Action<Player> PlayerDetected;
        public bool IsPlayerDetected { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                IsPlayerDetected = true;
                PlayerDetected?.Invoke(player);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                IsPlayerDetected = false;
                PlayerDetected?.Invoke(player);
            }
        }
    }
}