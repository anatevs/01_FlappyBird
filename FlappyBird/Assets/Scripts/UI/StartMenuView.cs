using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class StartMenuView : MonoBehaviour
    {
        public event Action OnScoreClicked;

        public event Action OnStartClicked;

        [SerializeField]
        private Button _scoreButton;

        [SerializeField]
        private Button _startButton;


    }
}