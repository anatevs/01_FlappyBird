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

        [SerializeField]
        private Transform _backPoint;

        [SerializeField]
        private Transform _viewTransform;

        [SerializeField]
        private float _rotSpeed = 1;

        [SerializeField]
        private float _maxRotation;

        [SerializeField]
        private BirdAnimation _birdAnimation;

        [SerializeField]
        private CollisionConfig _collisionConfig;

        private Rigidbody2D _rigidbody;

        private Vector2 _startPosition;

        private Vector2 _currentVelocity;

        private float _rotCoef;

        private bool _isControllingStarted;

        private const string GAMEPLAY_INPUT_MAP = "Gameplay";

        private InputActionMap _gameplayActionMap;

        public void SetInitPositionAndRotation()
        {
            transform.position = _startPosition;
            _viewTransform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }

        public void SetIsMoving(bool isMoving)
        {
            if (isMoving)
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

        public void SetIsPlaying(bool isPlaying)
        {
            if (isPlaying)
            {
                _gameplayActionMap.Enable();

                _birdAnimation.SetActive(isPlaying);

                _birdAnimation.SetFlapping();
            }
            else
            {
                _gameplayActionMap.Disable();

                _isControllingStarted = false;
            }
        }

        public bool IsPassX(float x)
        {
            return (_backPoint.position.x > x);
        }

        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _gameplayActionMap = GetComponent<PlayerInput>()
                .actions.FindActionMap(GAMEPLAY_INPUT_MAP);


            _startPosition = transform.position;

            _rotCoef = _maxRotation / _speed;

            SetIsMoving(false);
            SetIsPlaying(false);
        }

        private void Update()
        {
            RotateView();

            RestrictYBorder(_yBorders[0]);
            RestrictYBorder(_yBorders[1]);
        }

        private void RotateView()
        {
            if (_isControllingStarted)
            {
                var toRotation = Quaternion.AngleAxis(
                    _rotCoef * _rigidbody.velocity.y,
                    Vector3.forward);

                _viewTransform.rotation = Quaternion.Lerp(
                    _viewTransform.rotation, toRotation,
                    Time.deltaTime * _rotSpeed);
            }
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
            _isControllingStarted = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.name != _collisionConfig.TerrainName &&
                collision.transform.name != _collisionConfig.BackgroundName)
            {
                Debug.LogWarning("Name of terrain or background" +
                    " tilemap in config doesn't match collided object name");
            }

            if (collision.transform.name == _collisionConfig.TerrainName)
            {
                _birdAnimation.SetFall();
            }

            SetIsPlaying(false);

            OnRoundEnded?.Invoke();
        }
    }
}