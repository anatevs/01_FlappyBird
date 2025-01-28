using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class MainMenuView : MonoBehaviour
    {
        public event Action OnStartClicked;

        public event Action OnScoreClicked;

        public event Action OnExitClicked;

        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private Button _scoreButton;

        [SerializeField]
        private Button _exitButton;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(ClickStart);
            _scoreButton.onClick.AddListener(ClickScore);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveAllListeners();
            _scoreButton.onClick.RemoveAllListeners();
        }

        public void Show()
        {
            gameObject.SetActive(true);

            _startButton.onClick.AddListener(ClickStart);
            _scoreButton.onClick.AddListener(ClickScore);
            _exitButton.onClick.AddListener(ClickExit);
        }

        public void Hide()
        {
            gameObject.SetActive(false);

            _startButton.onClick.RemoveAllListeners();
            _scoreButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }

        private void ClickStart()
        {
            OnStartClicked?.Invoke();
        }

        private void ClickScore()
        {
            OnScoreClicked?.Invoke();
        }

        private void ClickExit()
        {
            OnExitClicked?.Invoke();
        }
    }
}