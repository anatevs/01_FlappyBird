using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "BirdAudoClipsConfig",
        menuName = "Configs/AudioClips")]
    public sealed class AudioClipsConfig : ScriptableObject
    {
        [SerializeField]
        private BirdSoundsStruct[] _clipsArray;

        private readonly Dictionary<BirdSoundType, AudioClip> _clips = new();

        private void OnEnable()
        {
            foreach (var clip in _clipsArray)
            {
                _clips.Add(clip.Name, clip.AudioClip);
            }
        }

        public AudioClip GetAudioClip(BirdSoundType sound)
        {
            return _clips[sound];
        }
    }

    [Serializable]
    public struct BirdSoundsStruct
    {
        public BirdSoundType Name;
        public AudioClip AudioClip;
    }

    public enum BirdSoundType
    {
        Flap,
        Point,
        Hit,
        Die
    }
}