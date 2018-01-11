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
    //FloorLayer fl = new FloorLayer();   //testing

    private Arena() {
        Debug.Log("Constructor");
        layers = new FloorLayer[2];
        for (int i = 0; i < layers.Length; i++) {
            layers[i] = new FloorLayer();
            Debug.Log("Layers[i]: " + layers[i]);
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
    /// UNIMPLEMENTED
    /// Highlights the valid tiles in range
    /// </summary>
    public void HighlightValidTiles(FloorLayers fl, int range) {
        HighlightValidTiles((int)fl, range);
    }
    public void HighlightValidTiles(int fl, int range) {
        //From top-left most corner
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
