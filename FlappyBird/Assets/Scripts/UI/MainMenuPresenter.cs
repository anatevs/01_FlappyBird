using GameManagement;
using GameManagment;

namespace UI
{
    public sealed class MainMenuPresenter
    {
        private readonly MainMenuView _view;

        private readonly ScoreWindowPresenter _scoreWindowPresenter;

        private readonly LocaleChangePresenter _localeChangePresenter;

        private readonly CounterPresenter _counterPresenter;

        private readonly StartGameManager _startManager;

        private readonly EndGameManager _endManager;

        private readonly ApplicationShutdown _applicationShutdown;

        public MainMenuPresenter(
            MainMenuView view,
            ScoreWindowPresenter scoreWindowPresenter,
            LocaleChangePresenter localeChangePresenter,
            CounterPresenter counterPresenter,
            StartGameManager startManager,
            EndGameManager endManager,
            ApplicationShutdown applicationShutdown
            )
        {
            _view = view;
            _scoreWindowPresenter = scoreWindowPresenter;
            _localeChangePresenter = localeChangePresenter;
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

            _localeChangePresenter.Show();

            _scoreWindowPresenter.OnOkClicked -= Show;

            _endManager.OnRoundEnded -= _scoreWindowPresenter.Show;

            _counterPresenter.Hide();
        }

        private void Hide()
        {
            _view.Hide();

            UnsubscribeAll();

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
            UnsubscribeAll();

            _applicationShutdown.QuitApp();
        }

        private void UnsubscribeAll()
        {
            _view.OnStartClicked -= StartGame;

            _view.OnScoreClicked -= ShowScore;

            _view.OnExitClicked -= ExitApp;

            _localeChangePresenter.Hide();
        }
    }
}