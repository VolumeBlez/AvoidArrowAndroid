using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Main.Assets._Project.CodeBase.Runtime.Infrastructure.Services.InputService
{
    public class InputHandler
    {
        public event Action<Vector2> InputMoveDirectionChanged = delegate { };

        private Input _input;

        private Input Input => _input ??= new Input();

        public void Init()
        {
            Input.Gameplay.Move.performed += ctx => OnMove(ctx);
            Input.Gameplay.Move.canceled += ctx => OnMove(ctx);
        }

        public void Enable()
        {
            Input.Enable();
        }

        public void Disable()
        {
            Input.Disable();
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            InputMoveDirectionChanged?.Invoke(ctx.ReadValue<Vector2>());
        }
    }
}