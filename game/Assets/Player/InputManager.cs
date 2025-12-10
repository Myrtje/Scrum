using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace game.Manager
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;

        public Vector2 Move { get; private set; }
        public bool InteractPressed { get; private set; }

        private InputActionMap _currentMap;

        private void Awake()
        {
            _currentMap = playerInput.currentActionMap;

            _currentMap.FindAction("Move").performed += OnMove;
            _currentMap.FindAction("Move").canceled += OnMove;

            _currentMap.FindAction("Interact").performed += OnInteract;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<Vector2>();
        }

        private void OnInteract(InputAction.CallbackContext context)
        {
            InteractPressed = context.performed;
        }

        private void OnEnable() => _currentMap.Enable();
        private void OnDisable() => _currentMap.Disable();
    }
}
