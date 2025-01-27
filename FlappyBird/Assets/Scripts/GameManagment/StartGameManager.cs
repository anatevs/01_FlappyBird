using GameCore;

namespace GameManagment
{
    public sealed class StartGameManager
    {
        private readonly Bird _bird;

        private readonly MovingSectionsController _sectionsController;

        private readonly PassedObstaclesCounter _obstaclesCounter;

        public StartGameManager(Bird bird,
            MovingSectionsController sectionsController,
            PassedObstaclesCounter obstaclesCounter)
        {
            _bird = bird;
            _sectionsController = sectionsController;
            _obstaclesCounter = obstaclesCounter;
        }

        public void StartGame()
        {
            _sectionsController.SetSectionsToInitX();

            _bird.SetInitPositionAndRotation();

            _bird.SetIsMoving(true);
            _bird.SetIsPlaying(true);

            _sectionsController.SetIsMoving(true);

            _obstaclesCounter.Init();
            _obstaclesCounter.SetIsCounting(true);
        }
    }
}