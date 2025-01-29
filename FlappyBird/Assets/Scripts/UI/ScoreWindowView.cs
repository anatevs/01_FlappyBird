using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class ScoreWindowView : MonoBehaviour
    {
        public event Action OnOkClicked;

        [SerializeField]
        private Button _okButton;

        [SerializeField]
        private TMP_Text _bestText;

        [SerializeField]
        private TMP_Text _scoreText;

        [SerializeField]
        private Image _background;

        public void Show()
        {
            gameObject.SetActive(true);
            _background.enabled = true;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetValues(string best, string score)
        {
            SetValue(best, _bestText);
            SetValue(score, _scoreText);
        }

        private void SetValue(string value, TMP_Text valueText)
        {
            valueText.text = value;
        }

        private void OnEnable()
        {
            _okButton.onClick.AddListener(ClickOk);
        }

        private void OnDisable()
        {
            _okButton.onClick.RemoveListener(ClickOk);
        }

        private void ClickOk()
        {
            OnOkClicked?.Invoke();
        }
    }
}