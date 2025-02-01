using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace GameCore
{
    public sealed class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSourcePrefab;

        [SerializeField]
        private Transform _poolTransform;

        private static AudioManager _instance;

        //private IObjectPool<AudioSource> _sourcePool1;

        private AudioClipsPool _sourcesPool;

        private int _poolInitSize = 4;

        //private string _pushMethodName;

        public static AudioManager Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            _sourcesPool = new AudioClipsPool(_audioSourcePrefab, _poolTransform, _poolInitSize);

            //_pushMethodName = nameof(AudioClipsPool.Push);
        }

        //public void PlaySound(AudioClip clip, float volume)
        //{
        //    //AudioSource source = _sourcePool1.Get();

        //    var source = _sourcesPool.Pool();

        //    source.clip = clip;

        //    source.volume = volume;

        //    source.Play();

        //    Invoke(_pushMethodName, clip.length);
        //}

        public IEnumerator PlaySound(AudioClip clip, float volume)
        {
            var source = _sourcesPool.Pool();

            source.clip = clip;

            source.volume = volume;

            source.Play();

            yield return new WaitForSeconds(clip.length);

            _sourcesPool.Push(source);
        }

        //private void PushSource(AudioSource source)
        //{
        //    _sourcePool1.Release(source);
        //}

        //public ObjectPool<T0>(
        //Func<T> createFunc,
        //Action<T> actionOnGet,
        //Action<T> actionOnRelease,
        //Action<T> actionOnDestroy,
        //bool collectionCheck,
        //int defaultCapacity,
        //int maxSize)
    }
}