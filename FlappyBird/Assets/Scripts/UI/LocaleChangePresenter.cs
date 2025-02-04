using GameManagement;

namespace UI
{
    public sealed class LocaleChangePresenter
    {
        private readonly LocaleChangeView _view;

        private readonly LocalesData _localization;

        public LocaleChangePresenter(LocaleChangeView view,
            LocalesData localization)
        {
            _view = view;
            _localization = localization;
        }

        public void Show()
        {
            _view.OnButtonClicked += _localization.SetNextLanguage;

            _localization.OnLocaleChanged += _view.SetName;

            _view.Show();
        }

        public void Hide()
        {
            _view.OnButtonClicked -= _localization.SetNextLanguage;

            _localization.OnLocaleChanged -= _view.SetName;

            _view.Hide();
        }
    }
}