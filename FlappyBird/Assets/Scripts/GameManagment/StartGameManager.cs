using GameCore;

namespace GameManagment
{
    public sealed class StartGameManager
    {
        private readonly Bird _bird;

        private readonly MovingSectionsController _sectionsController;

        private readonly PassedObstaclesCounter _obstaclesCounter;

        private readonly LeftScreenPosition _leftScreenPosition;

        public StartGameManager(Bird bird,
            MovingSectionsController sectionsController,
            PassedObstaclesCounter obstaclesCounter,
            LeftScreenPosition leftScreenPosition)
        {
            _bird = bird;
            _sectionsController = sectionsController;
            _obstaclesCounter = obstaclesCounter;
            _leftScreenPosition = leftScreenPosition;
        }

        public void StartGame()
        {
            _leftScreenPosition.InitPositions();

            _bird.SetInitRotation();

            _sectionsController.SetSectionsToInitX();

            _bird.SetIsMoving(true);
            _bird.SetIsPlaying(true);

            _sectionsController.SetIsMoving(true);

            _obstaclesCounter.Init();
            _obstaclesCounter.SetIsCounting(true);
        }
    }
}