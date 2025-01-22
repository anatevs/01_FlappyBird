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

        private Rigidbody2D _rigidbody;

        private Vector2 _startPosition;

        private bool _isPlaying;

        private Vector2 _currentVelocity;

        public void SetInitPosition()
        {
            transform.position = _startPosition;
        }

        public void SetIsPlaying(bool isPlaying)
        {
            _isPlaying = isPlaying;

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

        private void Start()
        {
            _startPosition = transform.position;

            SetIsPlaying(false);
        }

        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnClick()
        {
            if (_isPlaying)
            {
                _rigidbody.velocity = Vector2.up * _speed;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log($"collided with {collision.transform.name}");

            SetIsPlaying(false);

            OnRoundEnded?.Invoke();
        }
    }
}