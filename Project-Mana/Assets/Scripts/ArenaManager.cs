using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour {

    [SerializeField] GameObject[] tilePrefabs;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < Arena.Instance.GetLayersLength(); i++) {
            Debug.Log(Arena.Instance.GetLayers().Length);
            Debug.Log(Arena.Instance.GetLayers()[0]);
            Debug.Log(Arena.Instance.GetLayers()[1]);
            Debug.Log("Layer " + i);
            Arena.Instance.GetLayers()[i].SetTileMap();
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
        Instantiate(tilePrefabs[(int)type], new Vector3(p.x, layer, p.y), Quaternion.identity);
    }
}
