using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData {
    Point p;
    TileType type;

    public TileData() {
        p = new Point();
        type = TileType.defaultTile;
    }

    public Point GetPoint() {
        return p;
    }

    public void SetPoint(int x, int y) {
        SetPoint(new Point(x, y));
    }
    public void SetPoint(Point newPoint) {
        p = newPoint;
    }

    public TileType GetTileType() {
        return type;
    }
}