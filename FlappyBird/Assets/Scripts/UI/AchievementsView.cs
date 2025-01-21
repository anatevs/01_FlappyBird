using TMPro;
using UnityEngine;

namespace UI
{
    public sealed class AchievementsView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _bestText;

        [SerializeField]
        private TMP_Text _scoreText;

        public void SetValues(string best, string score)
        {
            SetValue(best, _bestText);
            SetValue(score, _scoreText);
        }

        private void SetValue(string value, TMP_Text valueText)
        {
            valueText.text = value;
        }
    }
}