using System;
using UnityEngine;

namespace GameCore
{
    public sealed class MapSectionsController : MonoBehaviour //StartListener, EndListener, PauseListener, ResumeListener
    {
        [SerializeField]
        private MapSection[] _sections;

        [SerializeField]
        private float _speed = 10f;

        [SerializeField]
        bool _isMoving;

        private Action[] _changePlaceActions;

        private Vector3[] _startPositions;


        [SerializeField]
        private bool _setToInitPos;

        public void StopMoving()
        {
            _isMoving = false;
        }

        public void SetSectionsToInitX()
        {
            transform.position = Vector3.zero;

            for (int i = 0; i < _sections.Length; i++)
            {
                _sections[i].transform.position = _startPositions[i];
            }
        }

        private void Start()
        {
            var camera = Camera.main;

            float leftCameraBorder = camera.transform.position.x
                - camera.aspect * camera.orthographicSize;

            _changePlaceActions = new Action[_sections.Length];

            _startPositions = new Vector3[_sections.Length];

            for (int i = 0; i < _sections.Length; i++)
            {
                _sections[i].LeftCameraBorder = leftCameraBorder;

                _startPositions[i] = _sections[i].transform.position;
            }
        }

        private void OnEnable()
        {
            for (int i = 0; i < _sections.Length; i++)
            {
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

            if (_setToInitPos)
            {
                _setToInitPos = false;

                SetSectionsToInitX();
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