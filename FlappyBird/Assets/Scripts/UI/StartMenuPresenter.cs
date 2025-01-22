using GameManagement;
using GameManagment;

namespace UI
{
    public sealed class StartMenuPresenter
    {
        private readonly StartMenuView _view;

        private readonly ScoreWindowPresenter _scoreWindowPresenter;

        private readonly StartGameManager _startManager; //or it will be gameListenersManager with StartGame method

        private readonly EndGameManager _endManager;

        public StartMenuPresenter(
            StartMenuView view,
            ScoreWindowPresenter scoreWindowPresenter,
            StartGameManager startManager,
            EndGameManager endManager)
        {
            _view = view;
            _scoreWindowPresenter = scoreWindowPresenter;
            _startManager = startManager;
            _endManager = endManager;

            Show();
        }

        private void Show()
        {
            _view.Show();

            _view.OnStartClicked += StartGame;

            _view.OnScoreClicked += ShowScore;

            _scoreWindowPresenter.OnOkClicked -= Show;

            _endManager.OnRoundEnded -= Show;
        }

        private void Hide()
        {
            _view.Hide();

            _view.OnStartClicked -= StartGame;

            _view.OnScoreClicked -= ShowScore;

            _scoreWindowPresenter.OnOkClicked += Show;

            _endManager.OnRoundEnded += Show;
        }

        private void StartGame()
        {
            Hide();

            _startManager.StartGame();
        }

        private void ShowScore()
        {
            Hide();

            _scoreWindowPresenter.Show();
        }
    }
}