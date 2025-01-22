using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class StartMenuView : MonoBehaviour
    {
        public event Action OnStartClicked;

        public event Action OnScoreClicked;

        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private Button _scoreButton;

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
        }

        public void Hide()
        {
            gameObject.SetActive(false);

            _startButton.onClick.RemoveAllListeners();
            _scoreButton.onClick.RemoveAllListeners();
        }

        private void ClickStart()
        {
            OnStartClicked?.Invoke();
        }

        private void ClickScore()
        {
            OnScoreClicked?.Invoke();
        }
    }
}