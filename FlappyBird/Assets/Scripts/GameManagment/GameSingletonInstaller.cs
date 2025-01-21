using GameCore;
using UnityEngine;

namespace GameManagement
{
    public class GameSingletonInstaller : MonoBehaviour
    {
        [SerializeField]
        private Bird _bird;

        [SerializeField]
        private MapSectionsController _sectionsController;

        private void Awake()
        {
            var singleton = GameSingleton.GetInstance();

            singleton.Bird = _bird;

            singleton.MapSectionsController
                = _sectionsController;
        }
    }
}