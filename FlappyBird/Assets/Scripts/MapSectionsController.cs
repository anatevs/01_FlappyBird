using System;
using UnityEngine;

namespace GameCore
{
    public sealed class MapSectionsController : MonoBehaviour
    {
        [SerializeField]
        private MapSection[] _sections;

        [SerializeField]
        private float _speed = 10f;

        [SerializeField]
        bool _isMoving;

        private Action[] _changePlaceActions;

        private void Awake()
        {
            var camera = Camera.main;

            float leftCameraBorder = camera.transform.position.x
                - camera.aspect * camera.orthographicSize;

            _changePlaceActions = new Action[_sections.Length];

            for (int i = 0; i < _sections.Length; i++)
            {
                _sections[i].LeftCameraBorder = leftCameraBorder;

                var otherIndex = (i + 1) % _sections.Length;

                _changePlaceActions[i] = ChangePlaceAction(i, otherIndex);

                _sections[i].OnBorderAchieved += _changePlaceActions[i];
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _sections.Length; i++)
            {
                _sections[i].OnBorderAchieved -= _changePlaceActions[i];
            }
        }

        private void Update()
        {
            if (_isMoving)
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
        }

        private Action ChangePlaceAction(int index, int otherIndex)
        {
            return () =>
            {
                _sections[index].PlaceLeftBorderToX(
                    _sections[otherIndex].GetRightBorderX());
            };
        }
    }
}