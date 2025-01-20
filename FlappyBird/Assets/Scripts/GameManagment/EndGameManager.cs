using UnityEngine;

namespace GameCore
{
    public class EndGameManager : MonoBehaviour
    {
        [SerializeField]
        private Bird _bird;

        [SerializeField]
        private MapSectionsController _sectionsController;

        private void OnEnable()
        {
            _bird.OnRoundEnded += _sectionsController.StopMoving;
        }

        private void OnDisable()
        {
            _bird.OnRoundEnded -= _sectionsController.StopMoving;
        }
    }
}