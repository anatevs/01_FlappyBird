using GameCore;
using System.Collections;
using UnityEngine;

namespace UI
{
    public sealed class AchievementsPresenter
    {
        private ResultInfoPresenter _bestPresenter;

        private ResultInfoPresenter _currentPresenter;

        private AchievementStorage _storage;

        public AchievementsPresenter(
            ResultInfoPresenter bestPresenter,
            ResultInfoPresenter currentPresenter,
            AchievementStorage storage)
        {
            _bestPresenter = bestPresenter;
            _currentPresenter = currentPresenter;
            _storage = storage;
        }


    }
}