using System;
using UnityEngine;

namespace UI
{
    public sealed class ScoreWindowPresenter : MonoBehaviour
    {
        public event Action OnHided;

        private ScoreWindowView _windowView;

        //private start menu presenter with OnScoreButtonClicked

        private AchievementsPresenter _achievementsPresenter;

        public ScoreWindowPresenter(
            ScoreWindowView windowView,
            //
            AchievementsPresenter achievementsPresenter)
        {
            _windowView = windowView;

            _achievementsPresenter = achievementsPresenter;

            //Show subscribtion to menu button
        }

        public void Show()
        {
            _windowView.gameObject.SetActive(true);

            _achievementsPresenter.Show();

            _windowView.OnOkClicked += Hide;
        }

        private void Hide()
        {
            OnHided?.Invoke();

            _windowView.gameObject.SetActive(false);

            _windowView.OnOkClicked -= Hide;
        }
    }
}