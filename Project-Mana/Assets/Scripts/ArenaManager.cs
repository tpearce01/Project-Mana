using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour {

    [SerializeField] GameObject[] tilePrefabs;
    public Point mapSize;
    public static readonly int heightMultiplier = 3;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < Arena.Instance.GetLayersLength(); i++) {
            Arena.Instance.GetLayers()[i].SetTileMap(mapSize.x, mapSize.y);
        }
        GenerateMap();
	}

    /// <summary>
    /// Spawn the ground and sky level map tiles
    /// </summary>
    public void GenerateMap() {
        //Generate ground tiles
        foreach (TileData tile in Arena.Instance.GetLayers()[0].GetTileMap()) {
            SpawnTile(tile.GetPoint(), tile.GetTileType(), 0);
        }
        //Generate Sky tiles
        foreach (TileData tile in Arena.Instance.GetLayers()[1].GetTileMap()) {
            SpawnTile(tile.GetPoint(), tile.GetTileType(), 1);
        }
    }

    /// <summary>
    /// Spawn a single tile.
    /// </summary>
    /// <param name="p"></param>
    /// <param name="type"></param>
    /// <param name="layer"></param>
    public void SpawnTile(Point p, TileType type, int layer) {
        Arena.Instance.GetTile(p, layer).sprite = (Instantiate(tilePrefabs[(int)type], new Vector3(p.x, layer * heightMultiplier, p.y), Quaternion.identity) as GameObject).GetComponentInChildren<SpriteRenderer>();
    }
}
