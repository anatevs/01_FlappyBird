using UnityEngine;

namespace GameCore
{
    public sealed class BirdAnimation : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private const string FLAP_STATE = "Flap";

        private const string FALL_BOOL = "IsFall";

        public void SetFlapping()
        {
            _animator.SetBool(FALL_BOOL, false);
            _animator.Play(FLAP_STATE);
        }

        public void SetFall()
        {
            _animator.SetBool(FALL_BOOL, true);
        }

        public void SetActive(bool isActive)
        {
            _animator.enabled = isActive;
        }
    }
}