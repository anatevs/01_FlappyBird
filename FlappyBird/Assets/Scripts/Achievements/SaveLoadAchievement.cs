using UnityEngine;

namespace GameCore
{
    public sealed class SaveLoadAchievement : MonoBehaviour
    {
        private readonly BestScoreStorage _bestScoreStorage =
            GameSingleton.GetInstance().BestScoreStorage;

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

            _bestScoreStorage.SetBest(bestResult);
        }

        private void Save()
        {
            var bestResult = _bestScoreStorage.GetBest();

            PlayerPrefs.SetInt(SAVE_KEY, bestResult);
        }
    }
}