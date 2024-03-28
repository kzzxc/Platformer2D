using UnityEngine;

namespace Enemy
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private float _patrolRadius = 5f;
        [SerializeField] private float _moveSpeed = 3f;
        
        private Rigidbody2D _rigidbody;
        private bool _movingRight = true;
        private Vector2 _patrolCenter;
    
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _patrolCenter = transform.position;
        }
    
        public void PatrolBehaviour()
        {
            float movement = (_movingRight) ? _moveSpeed : -_moveSpeed;
            _rigidbody.velocity = new Vector2(movement, _rigidbody.velocity.y);
        
            if (IsAtPatrolEdge())
                HandlePatrolEdge();
        }

        public bool GetDirection()
        {
            return _movingRight;
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
    }
}