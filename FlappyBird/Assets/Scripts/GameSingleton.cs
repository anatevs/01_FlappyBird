using GameManagement;
using GameManagment;
using System.Collections;
using UI;
using UnityEngine;

namespace GameCore
{
    public sealed class GameSingleton
    {
        private static GameSingleton _instance;

        private GameSingleton() { }

        public static GameSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameSingleton();
            }

            return _instance;
        }

        public AchievementStorage AchievementStorage => _achievementStorage;

        public Bird Bird { get; set; }

        public MapSectionsController MapSectionsController { get; set; }

        public AchievementsView AchievementsView { get; set; }///maybe not needed here, only in installer

        public AchievementsPresenter AchievementsPresenter { get; set; }

        public ScoreWindowPresenter ScoreWindowPresenter { get; set; }

        public StartGameManager StartGameManager { get; set; }

        public EndGameManager EndGameManager { get; set; }

        private readonly AchievementStorage _achievementStorage = new();
    }
}