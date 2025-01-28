using UnityEngine;

namespace GameCore
{
    public sealed class BirdAnimation : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private const string FLAP_STATE = "Flap";

        private const string FALL_TRIGGER = "Fall";

        public void SetFlapping()
        {
            _animator.Play(FLAP_STATE);
        }

        public void SetFall()
        {
            _animator.SetTrigger(FALL_TRIGGER);
        }

        public void SetActive(bool isActive)
        {
            _animator.enabled = isActive;
        }
    }
}