using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace GameCore
{
    public sealed class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;

        private IObjectPool<AudioSource> _sourcePool;

        private string _pushMethodName;

        public static AudioManager Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            _pushMethodName = nameof(PushSource);
        }

        public void PlaySound(AudioClip clip, float volume)
        {
            AudioSource source = _sourcePool.Get();

            source.clip = clip;

            source.volume = volume;

            source.Play();

            Invoke(_pushMethodName, clip.length);
        }

        private void PushSource(AudioSource source)
        {
            _sourcePool.Release(source);
        }


    }
}