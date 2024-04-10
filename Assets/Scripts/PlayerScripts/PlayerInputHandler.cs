using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerSkill _playerAbility;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAbility = GetComponent<PlayerSkill>();
        }

        private void OnMove(InputValue value)
        {
            _playerMovement.SetMoveInput(value.Get<Vector2>());
        }

        private void OnJump(InputValue value)
        {
            _playerMovement.Jump(value.isPressed);
        }

        private void OnAbility(InputValue value)
        {
            if (_playerAbility.AbilityAvailable)
            {
                _playerAbility.ActivateAbility();
            }
            else
            {
                Debug.Log("COOLDOWN");
            }
        }
    }
}