using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Arena Structure
 *  1. Arena (Consists of 2 FloorLayer)
 *      2. FloorLayer (Consists of many Tiles)
 *          3. Tile
 */
public class Arena {
    private static Arena instance;      // Singleton Reference
    FloorLayer[] layers;                // Air and Ground map layers
    Color highlightColor = new Color(.5f,.5f,.5f,.5f);
    Color defaultColor = new Color(1, 1, 1, 0.5f);

    private Arena() {
        layers = new FloorLayer[2];
        for (int i = 0; i < layers.Length; i++) {
            layers[i] = new FloorLayer();
        }
    }

    /// <summary>
    /// Singleton Instance
    /// If it does not exist, create it. Otherwise, return instance
    /// </summary>
    public static Arena Instance {
        get {
            if (instance == null) {
                instance = new Arena();
            }
            return instance;
        }
    }

    public FloorLayer[] GetLayers() {
        return layers;
    }
    public int GetLayersLength() {
        return layers.Length;
    }

    /// <summary>
    /// Gets the tilemap in the sky layer
    /// </summary>
    /// <returns></returns>
    FloorLayer GetSky() {
        return layers[1];
    }

    /// <summary>
    /// Gets the tilemap in the gound layer
    /// </summary>
    /// <returns></returns>
    FloorLayer GetGround() {
        return layers[0];
    }

    /// <summary>
    /// Highlights the valid tiles in range
    /// </summary>
    public void HighlightValidTiles(FloorLayers fl, int range, Point pos) {
        HighlightValidTiles((int)fl, range, pos);
    }
    public void HighlightValidTiles(int fl, int range, Point pos) {
        //From top-left most corner
        for (int x = pos.x - range; x <= pos.x + range; x++) {
            for (int y = pos.y - range; y <= pos.y + range; y++) {
                int absX = Mathf.Abs(x - pos.x);
                int absY = Mathf.Abs(y - pos.y);
                if (layers[fl].IsValidTile(x, y) && absX + absY <= range && (pos.x != x || pos.y != y)) {
                    layers[fl].GetTile(x, y).sprite.color = highlightColor;
                }
            }
        }
    }

    /// <summary>
    /// Reset ALL tile colors. INEFFICIENT - Consider keeping a list of points of the affected tiles, then
    /// clearing only those tiles.
    /// </summary>
    public void ClearHighlights() {
        for (int x = 0; x < layers[0].GetMapSize().x; x++) {
            for (int y = 0; y < layers[0].GetMapSize().y; y++) {
                for (int i = 0; i < layers.Length; i++) {
                    layers[i].GetTile(x, y).sprite.color = defaultColor;
                }
            }
        }
    }

    /// <summary>
    /// Gets a tile from the specified point and layer
    /// </summary>
    /// <param name="p"></param>
    /// <param name="fl"></param>
    public TileData GetTile(Point p, FloorLayers fl) {
        return GetTile(p, (int)fl);
    }
    public TileData GetTile(Point p, int fl) {
        return layers[fl].GetTile(p);
    }
}

public enum FloorLayers {
    Ground = 0,
    Sky = 1,
}
