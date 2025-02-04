using GameCore;
using GameManagment;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace GameManagement
{
    public sealed class GameSingletonInstaller : MonoBehaviour
    {
        [SerializeField]
        private Bird _bird;

        [SerializeField]
        private MovingSectionsController _sectionsController;

        [SerializeField]
        private LeftScreenPosition _leftScreenPosition;

        [SerializeField]
        private PassedObstaclesCounter _obstaclesCounter;

        [SerializeField]
        private EndGameManager _endGameManager;

        [SerializeField]
        private ScoreWindowView _scoreWindowView;

        [SerializeField]
        private CounterView _counterView;

        [SerializeField]
        private MainMenuView _mainMenuView;

        [SerializeField]
        private LocaleChangeView _localeChangeView;

        [SerializeField]
        private LocalesData _localesData;

        private void Awake()
        {
            var singleton = GameSingleton.GetInstance();

            InstallGameElements(singleton);

            InstallManagement(singleton);

            InstallUI(singleton);
        }

        private void InstallGameElements(GameSingleton singleton)
        {
            singleton.Bird = _bird;

            singleton.MapSectionsController
                = _sectionsController;

            singleton.PassedObstaclesCounter
                = _obstaclesCounter;
        }

        private void InstallManagement(GameSingleton singleton)
        {
            var leftScreenAlignments = new List<ILeftScreenAlignment>()
            {
                _bird,
                _sectionsController
            };

            _leftScreenPosition.Construct(leftScreenAlignments);

            var startManager = new StartGameManager(
                _bird, _sectionsController, _obstaclesCounter, _leftScreenPosition);

            singleton.StartGameManager = startManager;

            _endGameManager.Construct(_bird, _sectionsController);

            singleton.EndGameManager = _endGameManager;
        }

        private void InstallUI(GameSingleton singleton)
        {
            var scorePresenter = new ScoreWindowPresenter(
                _scoreWindowView,
                singleton.BestScoreStorage,
                singleton.PassedObstaclesCounter);

            var changeLocalesPresenter = new LocaleChangePresenter(
                _localeChangeView,
                _localesData);

            var counterPresenter = new CounterPresenter(
                _counterView,
                singleton.PassedObstaclesCounter);

            var mainMenuPresenter = new MainMenuPresenter(
                _mainMenuView,
                scorePresenter,
                changeLocalesPresenter,
                counterPresenter,
                singleton.StartGameManager,
                singleton.EndGameManager,
                new ApplicationShutdown());
        }
    }
}