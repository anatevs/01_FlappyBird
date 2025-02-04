using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class LocaleChangeView : MonoBehaviour
    {
        public event Action OnButtonClicked;

        [SerializeField]
        private Button _button;

        [SerializeField]
        private TMP_Text _languageName;

        public void Show()
        {
            _button.onClick.AddListener(ClickButton);

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _button.onClick.RemoveAllListeners();

            gameObject.SetActive(false);
        }

        public void SetName(string name)
        {
            _languageName.text = name;
        }

        private void ClickButton()
        {
            OnButtonClicked?.Invoke();
        }
    }
}