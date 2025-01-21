using GameCore;
using UI;
using UnityEngine;

namespace GameManagement
{
    public sealed class GameSingletonInstaller : MonoBehaviour
    {
        [SerializeField]
        private Bird _bird;

        [SerializeField]
        private MapSectionsController _sectionsController;

        [SerializeField]
        private AchievementsView _achievementsView;

        private void Awake()
        {
            var singleton = GameSingleton.GetInstance();

            singleton.Bird = _bird;

            singleton.MapSectionsController
                = _sectionsController;

            InstallUI(singleton);
        }

        private void InstallUI(GameSingleton singleton)
        {
            singleton.AchievementsView = _achievementsView;

            var achievPresenter = new AchievementsPresenter
                (singleton.AchievementsView,
                singleton.AchievementStorage);

            singleton.AchievementsPresenter = achievPresenter;
        }
    }
}