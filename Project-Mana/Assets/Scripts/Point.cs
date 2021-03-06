﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Point {
    public int x;   // x coordinate
    public int y;   // y coordinate

    public Point() {
        x = 0;
        y = 0;
    }

    public Point(int xNew, int yNew) {
        x = xNew;
        y = yNew;
    }
}
