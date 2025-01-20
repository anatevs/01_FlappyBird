using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameCore
{
    public class TilesSetter : MonoBehaviour
    {
        [SerializeField]
        private Tile _tile;

        [SerializeField]
        private Tilemap _map;

        [SerializeField]
        private Tilemap _mapBckgr;

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
        }

        private void Update()
        {
            if (_setTile)
            {
                SetToMap(new Vector3Int(_xy[0], _xy[1], 0));
                _setTile = false;
            }

            if (_removeTile)
            {
                RemoveFromMap(new Vector3Int(_xy[0], _xy[1], 0));
                _removeTile = false;
            }
        }

        private void SetToMap(Vector3Int pos)
        {
            _map.SetTile(pos, _tile);
        }

        private void RemoveFromMap(Vector3Int pos)
        {
            _map.SetTile(pos, null);
        }
    }
}