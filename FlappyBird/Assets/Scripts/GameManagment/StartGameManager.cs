using GameCore;

namespace GameManagment
{
    public sealed class StartGameManager
    {
        private readonly Bird _bird;

        private readonly MapSectionsController _sectionsController;

        public StartGameManager(Bird bird,
            MapSectionsController sectionsController)
        {
            _bird = bird;
            _sectionsController = sectionsController;
        }

        public void StartGame()
        {
            _sectionsController.SetSectionsToInitX();

            _bird.SetInitPosition();

            _bird.SetIsMoving(true);
            _bird.SetIsControlling(true);

            _sectionsController.SetIsMoving(true);
        }
    }
}