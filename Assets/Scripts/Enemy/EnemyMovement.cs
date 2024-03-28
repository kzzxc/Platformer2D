using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Patrol),typeof(Chase),typeof(SpriteRenderer))]
    public class EnemyMovement : MonoBehaviour
    {
        private Patrol _patrol;
        private Chase _chase;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _patrol = GetComponent<Patrol>();
            _chase = GetComponent<Chase>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            _chase.UpdateChaseBehaviour();

            if (!_chase.IsPlayerDetected())
                _patrol.PatrolBehaviour();
            
            UpdateSpriteDirection();
        }

        private void UpdateSpriteDirection()
        {
            bool isFacingRight = (_chase.IsPlayerDetected() && _chase.GetTarget().position.x > transform.position.x) || (!_chase.IsPlayerDetected() && _patrol.GetDirection());
            _spriteRenderer.flipX = !isFacingRight;
        }
    }
}
