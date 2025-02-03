using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCore
{
    [RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
    public sealed class Bird : MonoBehaviour,
        ILeftScreenAlignment
    {
        public event Action OnRoundEnded;

        public Vector2 InitPos
        {
            get => _initPos;
            set => _initPos = value;
        }

        [SerializeField]
        private float _speed = 5f;

        [SerializeField]
        private float _relativeCameraPos = 0.25f;

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

        [SerializeField]
        AudioClipsConfig _audioConfig;

        private Rigidbody2D _rigidbody;

        private Vector2 _initPos;

        private Vector2 _currentVelocity;

        private float _rotCoef;

        private bool _isControllingStarted;

        private Collider2D _lastTerrainCollider;

        private const string GAMEPLAY_INPUT_MAP = "Gameplay";

        private InputActionMap _gameplayActionMap;

        public void SetInitRotation()
        {
            _viewTransform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }

        public void SetToInitPosX()
        {
            transform.position = _initPos;
        }

        public void AlignXToScreen(float leftCameraBorder)
        {
            var camera = Camera.main;

            var cameraHalfWidth = camera.aspect * camera.orthographicSize;

            var xPos = leftCameraBorder + _relativeCameraPos * 2 * cameraHalfWidth;

            _initPos.x = xPos;

            SetToInitPosX();
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

                _birdAnimation.SetActive(true);

                _birdAnimation.SetFlapping();

                if (_lastTerrainCollider != null)
                {
                    _lastTerrainCollider.enabled = true;
                }
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

        private void Awake()
        {
            _initPos.y = transform.position.y;
        }

        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _gameplayActionMap = GetComponent<PlayerInput>()
                .actions.FindActionMap(GAMEPLAY_INPUT_MAP);

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

            PlaySound(BirdSoundType.Flap);
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
                PlaySound(BirdSoundType.Hit);

                _birdAnimation.SetFall();

                _lastTerrainCollider = collision.collider;

                _lastTerrainCollider.enabled = false;
            }
            else if (collision.transform.name == _collisionConfig.BackgroundName)
            {
                _birdAnimation.SetActive(false);
                PlaySound(BirdSoundType.Die);
            }

            SetIsPlaying(false);

            OnRoundEnded?.Invoke();
        }

        private void PlaySound(BirdSoundType soundType)
        {
            AudioManager.Instance.PlaySound(soundType);
        }
    }
}