using System;

namespace GameCore
{
    public class AchievementStorage
    {
        public event Action<int, int> OnAchievementResponded;

        private int _currentResult;

        private int _bestResult;

        //public AchievementStorage(int currentResult, int bestResult)
        //{
        //    _currentResult = currentResult;
        //    _bestResult = bestResult;
        //}

        public void SetNewResult(int result)
        {
            _currentResult = result;
        }

        public void UpdateBestResult()
        {
            if (_bestResult < _currentResult)
            {
                _bestResult = _currentResult;
            }
        }

        public void SendAchievements()
        {
            OnAchievementResponded?.Invoke(_bestResult, _currentResult);
        }

        public (int best, int current) GetAchievments()
        {
            return (_bestResult, _currentResult);
        }

        public void SetAchievements(int best, int current)
        {
            _bestResult = best;
            _currentResult = current;
        }
    }
}