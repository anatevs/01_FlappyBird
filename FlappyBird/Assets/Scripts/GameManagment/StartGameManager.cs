using GameCore;
using UnityEngine;

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
            Debug.Log("start game");

            _sectionsController.SetSectionsToInitX();

            _bird.SetInitPosition();

            _bird.SetIsPlaying(true);

            _sectionsController.SetIsMoving(true);
        }
    }
}