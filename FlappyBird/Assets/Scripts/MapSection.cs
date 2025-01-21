using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameCore
{
    public sealed class MapSection : MonoBehaviour
    {
        public event Action OnBorderAchieved;

        public float LeftCameraBorder
        {
            get => _leftCameraBorder;
            set => _leftCameraBorder = value;
        }

        [SerializeField]
        private Tilemap _backgroundTilemap;

        private float _rightBorderShift;

        private float _leftBorderShift;

        private float _leftCameraBorder;

        private void Start()
        {
            _rightBorderShift = (_backgroundTilemap.size.x
                + _backgroundTilemap.origin.x) * _backgroundTilemap.cellSize.x;

            _leftBorderShift = -_backgroundTilemap.origin.x * _backgroundTilemap.cellSize.x;
        }

        private void Update()
        {
            if (GetRightBorderX() <= _leftCameraBorder)
            {
                OnBorderAchieved?.Invoke();
            }
        }

        public void PlaceLeftBorderToX(float x)
        {
            transform.position = new Vector3(
                x + _leftBorderShift,
                transform.position.y,
                transform.position.z);
        }

        public float GetRightBorderX()
        {
            return transform.position.x + _rightBorderShift;
        }
    }
}