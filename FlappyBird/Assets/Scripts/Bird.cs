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

        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnClick()
        {
            _rigidbody.velocity = Vector2.up * _speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log($"collided with {collision.transform.name}");

            OnRoundEnded?.Invoke();
        }
    }
}