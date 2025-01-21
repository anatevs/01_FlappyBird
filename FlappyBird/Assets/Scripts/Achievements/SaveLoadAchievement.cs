using System.Collections;
using UnityEngine;

namespace GameCore
{
    public sealed class SaveLoadAchievement : MonoBehaviour
    {
        private readonly AchievementStorage _achievementStorage =
            GameSingleton.GetInstance().AchievementStorage;

        private const string SAVE_KEY = "BestResult";

        private void Awake()
        {
            Load();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void Load()
        {
            int bestResult = 0;

            if (PlayerPrefs.HasKey(SAVE_KEY))
            {
                bestResult = PlayerPrefs.GetInt(SAVE_KEY);
            }

            _achievementStorage.SetBest(bestResult);
        }

        private void Save()
        {
            (var bestResult, _) = _achievementStorage.GetAchievments();

            PlayerPrefs.SetInt(SAVE_KEY, bestResult);
        }
    }
}