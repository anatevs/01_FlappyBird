using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace GameManagement
{
    public sealed class LocalesData : MonoBehaviour
    {
        public event Action<string> OnLocaleChanged;

        private int _currentIndex;

        private List<Locale> _locales = new();

        private IEnumerator Start()
        {
            yield return LocalizationSettings.InitializationOperation;

            _locales = LocalizationSettings.AvailableLocales.Locales;

            for (int i = 0; i < _locales.Count; i++)
            {
                if (LocalizationSettings.SelectedLocale == _locales[i])
                {
                    _currentIndex = i;
                }
            }
        }

        public void SetNextLanguage()
        {
            if (_locales.Count > 0)
            {
                var nextIndex = GetNextIndex();

                LocalizationSettings.SelectedLocale = _locales[nextIndex];

                _currentIndex = nextIndex;

                var nextName = GetName(GetNextIndex());

                OnLocaleChanged?.Invoke(nextName);
            }
        }

        private int GetNextIndex()
        {
            return (_currentIndex + 1) % _locales.Count;
        }

        private string GetName(int i)
        {
            return _locales[i].LocaleName.Split('(', ')')[^2];
        }
    }
}