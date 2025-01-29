using UnityEngine;

namespace GameCore
{
    public interface ILeftScreenAlignment
    {
        public Vector2 InitPos { get; set; }

        public void SetPreviousInitPosX();

        public void AlignXToScreen(float leftCameraBorder);
    }
}