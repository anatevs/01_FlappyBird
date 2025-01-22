using System;

namespace UI
{
    public sealed class ScoreWindowPresenter
    {
        public event Action OnOkClicked;

        private readonly ScoreWindowView _windowView;

        private readonly AchievementsPresenter _achievementsPresenter;

        public ScoreWindowPresenter(
            ScoreWindowView windowView,
            AchievementsPresenter achievementsPresenter)
        {
            _windowView = windowView;
            _achievementsPresenter = achievementsPresenter;
        }

        public void Show()
        {
            _windowView.gameObject.SetActive(true);

            _achievementsPresenter.Show();

            _windowView.OnOkClicked += Hide;
        }

        private void Hide()
        {
            OnOkClicked?.Invoke();

            _windowView.gameObject.SetActive(false);

            _windowView.OnOkClicked -= Hide;
        }
    }
}