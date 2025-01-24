using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameCore
{
    [CreateAssetMenu(fileName = "ObstacleTilesConfig",
        menuName = "Configs/ObstacleTiles")]
    public class ObstaclesTilesConfig : ScriptableObject
    {
        public Tile[] TopTiles;

        public Tile BottomTile;

        public Tile BaseTile;

        public int ObstaclesPeriod;

        public int ZeroXPos;

        public int GroundHeight;

        public int TopBottomGap;
    }
}