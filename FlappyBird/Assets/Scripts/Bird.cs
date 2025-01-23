using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCore
{
    [RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
    public sealed class Bird : MonoBehaviour
    {
        public event Action OnRoundEnded;

        [SerializeField]
        private float _speed = 5f;

        [SerializeField]
        private float[] _yBorders = {-5, 5};

        private Rigidbody2D _rigidbody;

        private Vector2 _startPosition;

        private Vector2 _currentVelocity;

        private const string GAMEPLAY_MAP = "Gameplay";

        private InputActionMap _gameplayActionMap;

        public void SetInitPosition()
        {
            transform.position = _startPosition;
        }

        public void SetIsMoving(bool isPlaying)
        {
            if (isPlaying)
            {
                _rigidbody.isKinematic = false;
                _rigidbody.velocity = _currentVelocity;
            }
            else
            {
                _currentVelocity = _rigidbody.velocity;
                _rigidbody.isKinematic = true;
            }
        }

        public void SetIsControlling(bool isControlling)
        {
            if (isControlling)
            {
                _gameplayActionMap.Enable();
            }
            else
            {
                _gameplayActionMap.Disable();
            }
        }

        private void Start()
        {
            _gameplayActionMap = GetComponent<PlayerInput>()
                .actions.FindActionMap(GAMEPLAY_MAP);


            _startPosition = transform.position;

            SetIsMoving(false);
            SetIsControlling(false);
        }

        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            RestrictYBorder(_yBorders[0]);
            RestrictYBorder(_yBorders[1]);
        }

        private void RestrictYBorder(float yBorder)
        {
            if (Mathf.Abs(transform.position.y) >= Mathf.Abs(yBorder))
            {
                transform.position = new Vector2(
                    transform.position.x,
                    yBorder);
            }
        }

        private void OnMoveUp()
        {
            _rigidbody.velocity = Vector2.up * _speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log($"collided with {collision.transform.name}");

            SetIsControlling(false);

            OnRoundEnded?.Invoke();
        }
    }
}