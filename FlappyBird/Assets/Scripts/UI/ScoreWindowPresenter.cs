using GameCore;
using System;

namespace UI
{
    public sealed class ScoreWindowPresenter
    {
        public event Action OnOkClicked;

        private readonly ScoreWindowView _view;

        private readonly BestScoreStorage _bestStorage;

        private readonly PassedObstaclesCounter _obstaclesCounter;

        public ScoreWindowPresenter(
            ScoreWindowView view,
            BestScoreStorage bestStorage,
            PassedObstaclesCounter obstaclesCounter)
        {
            _view = view;
            _bestStorage = bestStorage;
            _obstaclesCounter = obstaclesCounter;
        }

        public void Show()
        {
            _view.Show();

            var best = _bestStorage.GetBest();
            var score = _obstaclesCounter.Count;

            _view.SetValues(best.ToString(), score.ToString());

            _view.OnOkClicked += Hide;
        }

        private void Hide()
        {
            OnOkClicked?.Invoke();

            _view.Hide();

            _bestStorage.UpdateBestResult(_obstaclesCounter.Count);

            _view.OnOkClicked -= Hide;
        }
    }
}