using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _patrolRadius = 5f;
        [SerializeField] private float _moveSpeed = 3f;

        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;
        private bool _movingRight = true;
        private Vector2 _patrolCenter;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _patrolCenter = transform.position;
        }

        private void Update()
        {
            Patrol();
        }

        private void Patrol()
        {
            float movement = (_movingRight) ? _moveSpeed : -_moveSpeed;
            _rigidbody.velocity = new Vector2(movement, _rigidbody.velocity.y);

            if (IsAtPatrolEdge())
            {
                HandlePatrolEdge();
            }
        }

        private bool IsAtPatrolEdge()
        {
            return (_movingRight && transform.position.x >= _patrolCenter.x + _patrolRadius) ||
                   (!_movingRight && transform.position.x <= _patrolCenter.x - _patrolRadius);
        }

        private void HandlePatrolEdge()
        {
            UpdateSpriteDirection();
            _movingRight = !_movingRight;
        }

        private void UpdateSpriteDirection()
        {
            _spriteRenderer.flipX = _movingRight;
        }
    }
}