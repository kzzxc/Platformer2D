using System;
using UnityEngine;
namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        
        private Rigidbody2D _enemyRb;

        private void Start()
        {
            _enemyRb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _enemyRb.velocity = new Vector2(_moveSpeed, 0f);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _moveSpeed = -_moveSpeed;
            FlipEnemyFacing();
        }

        private void FlipEnemyFacing()
        {
            transform.localScale = new Vector2(-(Mathf.Sign(_enemyRb.velocity.x)), 1f);
        }
    }
}