using GameManagement;
using GameManagment;

namespace UI
{
    public sealed class MainMenuPresenter
    {
        private readonly MainMenuView _view;

        private readonly ScoreWindowPresenter _scoreWindowPresenter;

        private readonly CounterPresenter _counterPresenter;

        private readonly StartGameManager _startManager; //or it will be gameListenersManager with StartGame method

        private readonly EndGameManager _endManager;

        private readonly ApplicationShutdown _applicationShutdown;

        public MainMenuPresenter(
            MainMenuView view,
            ScoreWindowPresenter scoreWindowPresenter,
            CounterPresenter counterPresenter,
            StartGameManager startManager,
            EndGameManager endManager,
            ApplicationShutdown applicationShutdown)
        {
            _view = view;
            _scoreWindowPresenter = scoreWindowPresenter;
            _counterPresenter = counterPresenter;
            _startManager = startManager;
            _endManager = endManager;
            _applicationShutdown = applicationShutdown;

            Show();
        }

        private void Show()
        {
            _view.Show();

            _view.OnStartClicked += StartGame;

            _view.OnScoreClicked += ShowScore;

            _view.OnExitClicked += ExitApp;



            _scoreWindowPresenter.OnOkClicked -= Show;

            _endManager.OnRoundEnded -= _scoreWindowPresenter.Show;

            _counterPresenter.Hide();
        }

        private void Hide()
        {
            _view.Hide();

            UnsubscribeView();

            _scoreWindowPresenter.OnOkClicked += Show;

            _endManager.OnRoundEnded += _scoreWindowPresenter.Show;

            _counterPresenter.Show();
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

        private void ExitApp()
        {
            UnsubscribeView();

            _applicationShutdown.QuitApp();
        }

        private void UnsubscribeView()
        {
            _view.OnStartClicked -= StartGame;

            _view.OnScoreClicked -= ShowScore;

            _view.OnExitClicked -= ExitApp;
        }
    }
}