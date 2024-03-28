using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(BoxCollider2D))]
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

        private void FixedUpdate()
        {
            Run();
            FlipSprite();
        }

        public void SetMoveInput(Vector2 moveInput)
        {
            _moveInput = moveInput;
        }

        public void Jump(bool isPressed)
        {
            if (_feetCollider.IsTouchingLayers(LayerMask.GetMask(Ground)) && isPressed)
                _rigidbody.velocity += new Vector2(0f, _jumpSpeed);
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

        private bool PlayerHasHorizontalSpeed() =>
            Mathf.Abs(_rigidbody.velocity.x) > Mathf.Epsilon;
    }
}