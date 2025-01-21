using UnityEngine;

namespace UI
{
    public sealed class ResultInfoPresenter : MonoBehaviour
    {
        private ResultInfoView _view;

        public void SetNewValue(int value)
        {
            _view.SetValue(value.ToString());
        }
    }
}