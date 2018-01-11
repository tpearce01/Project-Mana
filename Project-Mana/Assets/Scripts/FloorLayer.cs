using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLayer {
    TileData[,] tileMap;

    public FloorLayer() {
        tileMap = new TileData[1, 1];
    }

    /// <summary>
    /// Generate the tilemap (Default size: 10x10)
    /// </summary>
    public void SetTileMap() {
        //Placeholder
        tileMap = new TileData[10, 10];
        for (int x = 0; x < 10; x++) {
            for (int y = 0; y < 10; y++) {
                tileMap[x, y] = new TileData();
                tileMap[x, y].SetPoint(x, y);
            }
        }
    }
    public void SetTileMap(int width, int height) {
        //Placeholder
        tileMap = new TileData[width, height];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                tileMap[x, y] = new TileData();
                tileMap[x, y].SetPoint(x, y);
            }
        }
    }

    /// <summary>
    /// Get the 2d array of tile data
    /// </summary>
    /// <returns></returns>
    public TileData[,] GetTileMap() {
        return tileMap;
    }

    /// <summary>
    /// Get an individual tile
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public TileData GetTile(Point p) {
        return tileMap[p.x, p.y];
    }

    /// <summary>
    /// Determine if tile is in range
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public bool IsValidTile(Point p) {
        if (p.x >= 0 && p.x < tileMap.GetLength(0) &&
            p.y >= 0 && p.y < tileMap.GetLength(1)) {
            return true;
        }
        return false;
    }
}
