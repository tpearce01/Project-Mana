using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * class TileData
 * Holds data relevant for individual tiles
 */ 
public class TileData {
    Point p;        // World position
    TileType type;  // Type of tile
    public SpriteRenderer sprite;

    // Constructor
    public TileData() {
        p = new Point();
        type = TileType.defaultTile;
    }

    /// <summary>
    /// Get the world location of the tile
    /// </summary>
    /// <returns></returns>
    public Point GetPoint() {
        return p;
    }

    /// <summary>
    /// Set the world location of the tile. Does not actually move the tile.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void SetPoint(int x, int y) {
        SetPoint(new Point(x, y));
    }
    public void SetPoint(Point newPoint) {
        p = newPoint;
    }

    /// <summary>
    /// Get the type of tile
    /// </summary>
    /// <returns></returns>
    public TileType GetTileType() {
        return type;
    }
}