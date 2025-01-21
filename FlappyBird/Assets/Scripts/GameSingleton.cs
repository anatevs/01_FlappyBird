using System.Collections;
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


        private readonly AchievementStorage _achievementStorage = new();

        private Bird _bird;

        private MapSectionsController _mapSectionsController;
    }
}