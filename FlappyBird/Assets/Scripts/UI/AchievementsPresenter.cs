using GameCore;

namespace UI
{
    public sealed class AchievementsPresenter
    {
        private readonly AchievementsView _view;

        private readonly AchievementStorage _storage;

        public AchievementsPresenter(
            AchievementsView view,
            AchievementStorage storage)
        {
            _view = view;
            _storage = storage;
        }

        public void Show()
        {
            (int best, int score) = _storage.GetAchievments();

            _view.SetValues(best.ToString(), score.ToString());
        }
    }
}