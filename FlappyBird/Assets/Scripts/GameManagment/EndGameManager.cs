﻿using UnityEngine;
using GameCore;
using System;

namespace GameManagement
{
    public sealed class EndGameManager : MonoBehaviour
    {
        public event Action OnRoundEnded;

        private Bird _bird;

        private MapSectionsController _sectionsController;

        public void Construct(Bird bird, MapSectionsController sectionsController)
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
        }
    }
}