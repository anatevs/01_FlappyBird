using UnityEngine;
using GameCore;

namespace GameManagement
{
    public sealed class EndGameManager : MonoBehaviour
    {
        private readonly GameSingleton _singleton = GameSingleton.GetInstance();

        private Bird _bird;

        private MapSectionsController _sectionsController;

        private void Construct()
        {
            _bird = _singleton.Bird;
            _sectionsController = _singleton.MapSectionsController;
        }

        private void OnEnable()
        {
            Construct();

            _bird.OnRoundEnded += _sectionsController.StopMoving;
        }

        private void OnDisable()
        {
            _bird.OnRoundEnded -= _sectionsController.StopMoving;
        }
    }
}