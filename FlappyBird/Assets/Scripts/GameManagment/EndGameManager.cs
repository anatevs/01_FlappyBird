using UnityEngine;
using GameCore;

namespace GameManagement
{
    public sealed class EndGameManager : MonoBehaviour
    {
        private Bird _bird;

        private MapSectionsController _sectionsController;

        private void OnEnable()
        {
            _bird = GameSingleton.GetInstance().Bird;
            _sectionsController = GameSingleton.GetInstance().MapSectionsController;

            _bird.OnRoundEnded += _sectionsController.StopMoving;
        }

        private void OnDisable()
        {
            _bird.OnRoundEnded -= _sectionsController.StopMoving;
        }
    }
}