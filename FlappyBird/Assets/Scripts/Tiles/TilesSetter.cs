using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameCore
{
    public sealed class TilesSetter : MonoBehaviour
    {
        [SerializeField]
        private ObstaclesTilesConfig _config;

        [SerializeField]
        private Tilemap _map;

        [SerializeField]
        private Tilemap _mapBckgr;

        private readonly int[] _bottomRangeY = new int[2];

        private int _halfSizeY;

        private int[] _startXPositions;

        private int[] _furtherXPositions;

        [Header("Check one tile")]
        [SerializeField]
        private Tile _tile;

        [SerializeField]
        private int[] _xy = new int[2];

        [SerializeField]
        private bool _setTile;

        [SerializeField]
        private bool _removeTile;

        private void Start()
        {
            //Debug.Log(_mapBckgr.size);
            //Debug.Log(_mapBckgr.cellBounds);

            _halfSizeY = _mapBckgr.size.y / 2;

            _bottomRangeY[0] = _config.GroundHeight - _halfSizeY;
            _bottomRangeY[1] = _halfSizeY - 1 - _config.TopBottomGap;

            _furtherXPositions = new int[_mapBckgr.size.x / _config.ObstaclesPeriod];
            _startXPositions = new int[_furtherXPositions.Length
                + _mapBckgr.cellBounds.position.x / _config.ObstaclesPeriod];

            var firstPos = _config.ZeroXPos
                - (_furtherXPositions.Length - _startXPositions.Length)
                * _config.ObstaclesPeriod;
            int i_start = 0;
            for (int i = 0; i < _furtherXPositions.Length; i++)
            {
                var pos = firstPos + i * _config.ObstaclesPeriod;
                _furtherXPositions[i] = pos;

                if (pos >= _config.ZeroXPos)
                {
                    _startXPositions[i_start] = pos;
                    i_start++;
                }
            }
        }

        private void Update()
        {
            if (_setTile)
            {
                //SetToMap(new Vector3Int(_xy[0], _xy[1], 0), _tile);

                //SetObstacle(_xy[0]);
                SetFurtherMapObstacles();
                _setTile = false;
            }

            //if (_removeTile)
            //{
            //    RemoveFromMap(new Vector3Int(_xy[0], _xy[1], 0));
            //    _removeTile = false;
            //}
        }

        private void SetStartMapObstacles()
        {
            SetMapObstacles(_startXPositions);
        }

        private void SetFurtherMapObstacles()
        {
            SetMapObstacles(_furtherXPositions);
        }

        private void SetMapObstacles(int[] xPositions)
        {
            foreach (var x in xPositions)
            {
                SetObstacle(x);
            }
        }

        private void SetObstacle(int x)
        {
            var bottomY = Random.Range(_bottomRangeY[0], _bottomRangeY[1]);

            for (int i = 0; i < _config.TopTiles.Length; i++)
            {
                SetToMap(
                    x - 1 + i,
                    bottomY,
                    _config.TopTiles[i]);
            }

            for (int i = bottomY - 1; i >= -_halfSizeY; i--)
            {
                SetToMap(x, i, _config.BaseTile);
            }

            var topY = bottomY + _config.TopBottomGap + 1;

            SetToMap(x, topY, _config.BottomTile);

            for (int i = topY + 1; i < _halfSizeY; i++)
            {
                SetToMap(x, i, _config.BaseTile);
            }
        }

        private void SetToMap(int x, int y, Tile tile)
        {
            _map.SetTile(new Vector3Int(x, y, 0), tile);
        }

        private void RemoveFromMap(int x, int y)
        {
            _map.SetTile(new Vector3Int(x, y, 0), null);
        }
    }
}