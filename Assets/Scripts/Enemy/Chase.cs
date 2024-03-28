using PlayerScripts;
using UnityEngine;

namespace Enemy
{
    public class Chase : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private ChaseArea _chaseArea;
        
        private Transform _target;
        
        private void OnEnable()
        {
            _chaseArea.PlayerDetected += SetTarget;
        }

        private void OnDisable()
        {
            _chaseArea.PlayerDetected -= SetTarget;
        }

        public void UpdateChaseBehaviour()
        {
            if (_chaseArea.IsPlayerDetected)
                ChaseBehaviour();
        }

        public bool IsPlayerDetected()
        {
            return _chaseArea.IsPlayerDetected;
        }

        public Transform GetTarget()
        {
            return _target;
        }

        private void ChaseBehaviour()
        {
            if (_target != null)
                transform.position = Vector2.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
        }

        private void SetTarget(Player player)
        {
            _target = player.transform;
        }
    }
}