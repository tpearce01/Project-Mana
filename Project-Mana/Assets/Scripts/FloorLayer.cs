using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLayer {
    TileData[,] tileMap;

    public FloorLayer() {
        tileMap = new TileData[1, 1];
    }

    /// <summary>
    /// Generate the tilemap
    /// </summary>
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
        return GetTile(p.x, p.y);
    }
    public TileData GetTile(int x, int y) {
        return tileMap[x, y];
    }

    /// <summary>
    /// Determine if tile is in range
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public bool IsValidTile(int x, int y) {
        if (x >= 0 && x < tileMap.GetLength(0) &&
            y >= 0 && y < tileMap.GetLength(1)
            && tileMap[x, y].GetTileType() != TileType.impassableTile) {
            return true;
        }
        return false;
    }
    public bool IsValidTile(Point p) {
        return IsValidTile(p.x, p.y);
    }

    public Point GetMapSize() {
        return new Point(tileMap.GetLength(0), tileMap.GetLength(1));
    }
}
