using Main.Assets._Project.CodeBase.Runtime.Infrastructure.Services.InputService;
using Reflex.Attributes;
using UnityEngine;

namespace Main.Assets._Project.CodeBase.Runtime.Core.Player.Systems
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        private Rigidbody2D _rb;
        private InputHandler _inputHandler;
        private PlayerController _playerController;
        private Vector2 _currentMoveDirection;

        [Inject]
        private void Construct(InputHandler input, PlayerController playerController)
        {
            _inputHandler = input;
            _playerController = playerController;

            _inputHandler.InputMoveDirectionChanged += OnMoveDirectionChanged;
        }

        private void Awake() => 
            _rb = GetComponent<Rigidbody2D>();

        private void OnDisable() =>
            _inputHandler.InputMoveDirectionChanged -= OnMoveDirectionChanged;

        private void OnMoveDirectionChanged(Vector2 direction) =>
            _currentMoveDirection = direction.normalized;

        private void FixedUpdate()
        {
            if(_playerController.CanMove())
                _rb.velocity = _currentMoveDirection * _moveSpeed;
            else
                _rb.velocity = Vector2.zero;
        }
    }
}