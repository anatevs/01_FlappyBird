using UnityEngine;
using GameCore;
using System;

namespace GameManagement
{
    public sealed class EndGameManager : MonoBehaviour
    {
        public event Action OnRoundEnded;

        [SerializeField]
        private PassedObstaclesCounter _obstaclesCounter;

        private Bird _bird;

        private MovingSectionsController _sectionsController;

        public void Construct(Bird bird, MovingSectionsController sectionsController)
        {
            _bird = bird;
            _sectionsController = sectionsController;
        }

        private void OnEnable()
        {
            _bird.OnRoundEnded += MakeOnRoundEnd;
        }

        private void OnDisable()
        {
            _bird.OnRoundEnded -= MakeOnRoundEnd;
        }

        private void MakeOnRoundEnd()
        {
            OnRoundEnded?.Invoke();

            _sectionsController.SetIsMoving(false);

            _obstaclesCounter.SetIsCounting(false);
        }
    }
}