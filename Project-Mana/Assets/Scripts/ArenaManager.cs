using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour {

    [SerializeField] GameObject[] tilePrefabs;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < Arena.Instance.GetLayers().Length; i++) {
            Debug.Log(Arena.Instance.GetLayers().Length);
            Debug.Log(Arena.Instance.GetLayers()[0]);
            Debug.Log(Arena.Instance.GetLayers()[1]);
            Debug.Log("Layer " + i);
            Arena.Instance.GetLayers()[i].SetTileMap();
        }
        GenerateMap();
	}


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

    public void SpawnTile(Point p, TileType type, int layer) {
        Instantiate(tilePrefabs[(int)type], new Vector3(p.x, layer, p.y), Quaternion.identity);
    }
}
