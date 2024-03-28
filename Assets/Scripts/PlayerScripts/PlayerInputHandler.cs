using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void OnMove(InputValue value)
        {
            _playerMovement.SetMoveInput(value.Get<Vector2>());
        }

        private void OnJump(InputValue value)
        {
            _playerMovement.Jump(value.isPressed);
        }
    }
}