using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _patrolRadius = 5f;
        [SerializeField] private float _moveSpeed = 3f;
        
        [SerializeField] private Transform _target;
        [SerializeField] private float _detectionDistance = 2f;

        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;
        private bool _movingRight = true;
        private Vector2 _patrolCenter;
        private bool _isFollow;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _patrolCenter = transform.position;
        }

        private void Update()
        {
            if (_isFollow == false)
            {
                Patrol();
            }
            else
            {
                Chase();
            }
        }

        private void Patrol()
        {
            float movement = (_movingRight) ? _moveSpeed : -_moveSpeed;
            _rigidbody.velocity = new Vector2(movement, _rigidbody.velocity.y);

            if (IsAtPatrolEdge())
            {
                HandlePatrolEdge();
            }

            UpdateSpriteDirection();
            TrackTarget();
        }

        private bool IsAtPatrolEdge()
        {
            return (_movingRight && transform.position.x >= _patrolCenter.x + _patrolRadius) ||
                   (!_movingRight && transform.position.x <= _patrolCenter.x - _patrolRadius);
        }

        private void HandlePatrolEdge()
        {
            _movingRight = !_movingRight;
        }

        private void UpdateSpriteDirection()
        {
            if (_isFollow)
            {
                bool isTargetToTheRight = transform.position.x < _target.position.x;

                _spriteRenderer.flipX = !isTargetToTheRight;
            }
            else
            {
                _spriteRenderer.flipX = !_movingRight;
            }
        }

        private void Chase()
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, (_moveSpeed + 1f) * Time.deltaTime);
            UpdateSpriteDirection();
            TrackTarget();
        }

        private void TrackTarget()
        {
            float distanceToTarget = Vector2.Distance(transform.position, _target.position);
            
            _isFollow = distanceToTarget < _detectionDistance;
        }
    }
}