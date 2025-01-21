using System;

namespace GameCore
{
    public class AchievementStorage
    {
        public event Action<int, int> OnAchievementResponded;

        public event Action<int> OnScoreChanged;

        public event Action<int> OnBestChanged;

        private int _scoreResult;

        private int _bestResult;

        public void UpdateBestResult()
        {
            if (_bestResult < _scoreResult)
            {
                _bestResult = _scoreResult;
            }
        }

        public void SendAchievements()
        {
            OnAchievementResponded?.Invoke(_bestResult, _scoreResult);
        }

        public (int best, int current) GetAchievments()
        {
            return (_bestResult, _scoreResult);
        }

        public void SetScore(int score)
        {
            _scoreResult = score;

            OnScoreChanged?.Invoke(_scoreResult);
        }

        public void SetBest(int best)
        {
            _bestResult = best;
        }
    }
}