using TMPro;
using UnityEngine;

namespace UI
{
    public sealed class CounterView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _value;

        public void SetValue(string valueText)
        {
            _value.text = valueText;
        }
    }
}