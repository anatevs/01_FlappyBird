namespace GameCore
{
    public sealed class BestScoreStorage
    {
        private int _bestResult;

        public void UpdateBestResult(int score)
        {
            if (_bestResult < score)
            {
                _bestResult = score;
            }
        }

        public int GetBest()
        {
            return _bestResult;
        }

        public void SetBest(int best)
        {
            _bestResult = best;
        }
    }
}