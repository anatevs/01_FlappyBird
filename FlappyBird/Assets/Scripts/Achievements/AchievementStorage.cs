using System;
using UnityEngine;

namespace GameCore
{
    public class AchievementStorage
    {
        public event Action<int, int> OnAchievementResponded;

        private int _newResult;

        private int _bestResult;

        public void SetNewResult(int result)
        {
            _newResult = result;
        }

        public void UpdateBestResult()
        {
            if (_bestResult < _newResult)
            {
                _bestResult = _newResult;
            }
        }

        public void SendAchievements()
        {
            OnAchievementResponded?.Invoke(_bestResult, _newResult);
        }
    }
}