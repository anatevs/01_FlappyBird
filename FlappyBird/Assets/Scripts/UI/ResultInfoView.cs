using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public sealed class ResultInfoView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _valueText;

        public void SetValue(string value)
        {
            _valueText.text = value;
        }
    }
}