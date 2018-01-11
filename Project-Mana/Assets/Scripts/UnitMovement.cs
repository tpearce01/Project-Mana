using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour {
    [SerializeField] Point currentPos;
    [SerializeField] int moveRange;
    [SerializeField] FloorLayers currentLayer;

    bool isColored = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !isColored) {
            InitiateMovement();
            isColored = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isColored) {
            Arena.Instance.ClearHighlights();
            isColored = false;
        }
    }

    void InitiateMovement() {
        Arena.Instance.HighlightValidTiles(currentLayer, moveRange, currentPos);
    }
}
