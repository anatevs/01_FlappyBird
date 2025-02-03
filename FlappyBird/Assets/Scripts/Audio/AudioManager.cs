using System.Collections;
using UnityEngine;

namespace GameCore
{
    public sealed class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSourcePrefab;

        [SerializeField]
        private Transform _poolTransform;

        [SerializeField]
        AudioClipsConfig _audioConfig;

        private static AudioManager _instance;

        private AudioClipsPool _sourcesPool;

        private readonly int _poolInitSize = 4;

        public static AudioManager Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            _sourcesPool = new AudioClipsPool(_audioSourcePrefab, _poolTransform, _poolInitSize);
        }

        public void PlaySound(BirdSoundType soundType)
        {
            var (clip, volume) = _audioConfig.GetAudioClip(soundType);

            StartCoroutine(Instance.PlaySoundCoroutine(clip, volume));
        }

        public void PlaySound(BirdSoundType soundType,
            AudioClipsConfig audioConfig)
        {
            var (clip, volume) = audioConfig.GetAudioClip(soundType);

            StartCoroutine(Instance.PlaySoundCoroutine(clip, volume));
        }

        private IEnumerator PlaySoundCoroutine(AudioClip clip, float volume)
        {
            var source = _sourcesPool.Pool();

            source.clip = clip;

            source.volume = volume;

            source.Play();

            yield return new WaitForSeconds(clip.length);

            _sourcesPool.Push(source);
        }
    }
}