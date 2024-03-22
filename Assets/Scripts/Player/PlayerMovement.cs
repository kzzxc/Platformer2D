using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly string Ground = "Ground";

        [SerializeField] private float _runSpeed = 10f;
        [SerializeField] private float _jumpSpeed = 5f;

        private Vector2 _moveInput;
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private BoxCollider2D _feetCollider;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _feetCollider = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            Run();
            FlipSprite();
        }

        private void OnMove(InputValue value)
        {
            _moveInput = value.Get<Vector2>();
        }

        private void Run()
        {
            Vector2 playerVelocity = new Vector2(_moveInput.x * _runSpeed, _rigidbody.velocity.y);
            _rigidbody.velocity = playerVelocity;

            _animator.SetBool(IsRunning, PlayerHasHorizontalSpeed());
        }

        private void FlipSprite()
        {
            if (PlayerHasHorizontalSpeed())
                transform.localScale = new Vector2(Mathf.Sign(_rigidbody.velocity.x), 1f);
        }

        private void OnJump(InputValue value)
        {
            if (_feetCollider.IsTouchingLayers(LayerMask.GetMask(Ground)))
                if (value.isPressed)
                    _rigidbody.velocity += new Vector2(0f, _jumpSpeed);
        }

        private bool PlayerHasHorizontalSpeed() =>
            Mathf.Abs(_rigidbody.velocity.x) > Mathf.Epsilon;
    }
}