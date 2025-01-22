﻿using GameCore;
using GameManagment;
using UI;
using UnityEngine;

namespace GameManagement
{
    public sealed class GameSingletonInstaller : MonoBehaviour
    {
        [SerializeField]
        private Bird _bird;

        [SerializeField]
        private MapSectionsController _sectionsController;

        [SerializeField]
        private EndGameManager _endGameManager;

        [SerializeField]
        private AchievementsView _achievementsView;

        [SerializeField]
        private ScoreWindowView _scoreWindowView;

        [SerializeField]
        private StartMenuView _startMenuView;

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
        }

        private void InstallManagement(GameSingleton singleton)
        {
            var startManager = new StartGameManager(_bird, _sectionsController);

            singleton.StartGameManager = startManager;

            _endGameManager.Construct(_bird, _sectionsController);

            singleton.EndGameManager = _endGameManager;
        }

        private void InstallUI(GameSingleton singleton)
        {
            singleton.AchievementsView = _achievementsView;

            var achievPresenter = new AchievementsPresenter
                (singleton.AchievementsView,
                singleton.AchievementStorage);

            singleton.AchievementsPresenter = achievPresenter;

            var scorePresenter = new ScoreWindowPresenter(
                _scoreWindowView, achievPresenter);

            singleton.ScoreWindowPresenter = scorePresenter;

            var startPresenter = new StartMenuPresenter(
                _startMenuView, scorePresenter,
                singleton.StartGameManager,
                singleton.EndGameManager);
        }
    }
}