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

        public Bird Bird
        {
            get => _bird;
            set => _bird = value;
        }

        public MapSectionsController MapSectionsController
        {
            get => _mapSectionsController;
            set => _mapSectionsController = value;
        }

        public AchievementsView AchievementsView
        {
            get => _achievementsView;
            set => _achievementsView = value;
        }

        public AchievementsPresenter AchievementsPresenter
        {
            get => _achievementsPresenter;
            set => _achievementsPresenter = value;
        }

        private readonly AchievementStorage _achievementStorage = new();

        private Bird _bird;

        private MapSectionsController _mapSectionsController;

        private AchievementsView _achievementsView; ///maybe not needed here, only in installer

        private AchievementsPresenter _achievementsPresenter;
    }
}