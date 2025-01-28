using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "CollisionConfig",
        menuName = "Configs/Collision")]
    public sealed class CollisionConfig : ScriptableObject
    {
        public string TerrainName => _terrainTilemapName;

        public string BackgroundName => _backgroundTilemapName;

        [SerializeField]
        private string _terrainTilemapName;

        [SerializeField]
        private string _backgroundTilemapName;
    }
}