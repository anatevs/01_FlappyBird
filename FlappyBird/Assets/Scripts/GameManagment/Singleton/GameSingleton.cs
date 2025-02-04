using GameManagement;
using GameManagment;

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


        public Bird Bird { get; set; }

        public MovingSectionsController MapSectionsController { get; set; }

        public PassedObstaclesCounter PassedObstaclesCounter { get; set; }

        public BestScoreStorage BestScoreStorage => _bestScoreStorage;

        public StartGameManager StartGameManager { get; set; }

        public EndGameManager EndGameManager { get; set; }


        private readonly BestScoreStorage _bestScoreStorage = new();
    }
}