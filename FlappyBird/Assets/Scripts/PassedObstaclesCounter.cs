using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameCore
{
    public sealed class PassedObstaclesCounter : MonoBehaviour
    {
        [SerializeField]
        private ObstaclesTilesConfig _obstaclesConfig; //period, zeroPos

        [SerializeField]
        private Tilemap _backgroundMap; //cellSize

        [SerializeField]
        private Bird _bird;

        [SerializeField]
        private Transform _gridTransform;

        private float _targetLocalPos;

        private int _counter = 0;

        private bool _isCounting;

        private void Update()
        {
            if (_isCounting)
            {
                if (_bird.IsPassX(_targetLocalPos + _gridTransform.position.x))
                {
                    _counter++;

                    Debug.Log($"passed {_counter}");

                    SetNextTargetPos();
                }
            }
        }

        public void Init()
        {
            _targetLocalPos = _obstaclesConfig.ZeroXPos + _backgroundMap.cellSize.x;

            _counter = 0;
        }

        public void SetIsCounting(bool isCounting)
        {
            _isCounting = isCounting;
        }

        private void SetNextTargetPos()
        {
            _targetLocalPos += _obstaclesConfig.ObstaclesPeriod;
        }
    }
}