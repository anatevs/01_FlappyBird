using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class ScoreWindowView : MonoBehaviour
    {
        public event Action OnOkClicked;

        [SerializeField]
        private Button _okButton;

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