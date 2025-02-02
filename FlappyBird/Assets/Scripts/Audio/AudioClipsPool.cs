using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public sealed class AudioClipsPool
    {
        private readonly AudioSource _sourcePrefab;

        private Transform _poolTransform;

        private readonly Queue<AudioSource> _pool = new();

        public AudioClipsPool(AudioSource sourcePrefab, Transform poolTransform, int initSize)
        {
            _sourcePrefab = sourcePrefab;
            _poolTransform = poolTransform;
            
            for(int i = 0; i < initSize; i++)
            {
                var source = GetNewInstance();
                _pool.Enqueue(source);
            }
        }

        public AudioSource Pool()
        {
            if (_pool.Count > 0)
            {
                return _pool.Dequeue();
            }
            else
            {
                return GetNewInstance();
            }
        }

        public void Push(AudioSource source)
        {
            _pool.Enqueue(source);
        }

        private AudioSource GetNewInstance()
        {
            return GameObject.Instantiate(_sourcePrefab, _poolTransform);
        }
    }
}