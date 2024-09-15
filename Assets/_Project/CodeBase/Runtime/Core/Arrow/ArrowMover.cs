using UnityEngine;

namespace Main.Assets._Project.CodeBase.Runtime.Core.Arrow
{
    public class ArrowMover : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float _moveSpeed = 15f;
        [SerializeField] private float _detectionDistance = 2f;
        [SerializeField] private float _reflectionSpread = 0.4f;

        [Header("Collision Detection")]
        [SerializeField] private LayerMask _wallLayer;

        [Header("Physics")]
        [SerializeField] private Rigidbody2D _rb;

        private Vector2 _direction;
        private RaycastHit2D _hitInfo;
        private Transform _self;

        private void Awake()
        {
            _self = transform;
        }

        public void Init()
        {
            _self.Rotate(Vector3.forward, Random.Range(0f, 180f));
        }

        private void Update()
        {
            DetectWallCollision();
            UpdateDirection();
        }

        private void LateUpdate()
        {
            MoveArrow();
        }

        private void DetectWallCollision()
        {
            _hitInfo = Physics2D.Raycast(_self.position, _self.up, _detectionDistance, _wallLayer);
        }

        private void UpdateDirection()
        {
            if (_hitInfo.collider != null)
            {
                Vector2 reflectionVector = CalculateReflectionVector();
                _direction = reflectionVector.normalized;
                RotateArrow(_direction);
            }
            else
            {
                _direction = _self.up;
            }
        }

        private Vector2 CalculateReflectionVector()
        {
            Vector2 rayDirection = _self.up;
            Vector2 reflectionVector = rayDirection - 2 * Vector2.Dot(_hitInfo.normal, rayDirection) * _hitInfo.normal;

            reflectionVector += new Vector2
                (Random.Range(-_reflectionSpread, _reflectionSpread), Random.Range(-_reflectionSpread, _reflectionSpread));

            return reflectionVector;
        }

        private void RotateArrow(Vector2 direction)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, direction));
            _rb.SetRotation(rotation);
        }

        private void MoveArrow()
        {
            _rb.velocity = _direction * _moveSpeed;
        }
    }
}