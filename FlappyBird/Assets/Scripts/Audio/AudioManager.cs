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

        private float _volume = 1f;

        public static AudioManager Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            _sourcesPool = new AudioClipsPool(_audioSourcePrefab, _poolTransform, _poolInitSize);
        }

        public void PlaySound(BirdSoundType soundType,
            float volume)
        {
            var sound = _audioConfig.GetAudioClip(soundType);

            StartCoroutine(Instance.PlaySound(sound, volume));
        }

        public void PlaySound(BirdSoundType soundType,
            float volume,
            AudioClipsConfig audioConfig)
        {
            var sound = audioConfig.GetAudioClip(soundType);

            StartCoroutine(Instance.PlaySound(sound, volume));
        }

        private IEnumerator PlaySound(AudioClip clip, float volume)
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