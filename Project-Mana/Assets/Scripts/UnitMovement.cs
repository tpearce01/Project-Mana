using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour {
    [SerializeField] Point currentPos;
    [SerializeField] int moveRange;
    [SerializeField] FloorLayers currentLayer;

    Point targetPos;
    bool isColored = false;

    void Start() {
        gameObject.transform.position = new Vector3(currentPos.x, (int)currentLayer * ArenaManager.heightMultiplier, currentPos.y);
    }

    void Update() {
        Controls();
    }

    void InitiateMovement() {
        targetPos = new Point(currentPos.x, currentPos.y);
        Arena.Instance.HighlightValidTiles(currentLayer, moveRange, currentPos);
        Arena.Instance.HighlightMovementTargetTile(currentLayer, targetPos);
    }

    /*
     * Movement Controls
     * Escape - Cancel Movement
     * Spacebar - Initiate Movement / Confirm Movement
     * Arrow Keys - Move target location
     */ 
    void Controls() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!isColored) {
                InitiateMovement();
                isColored = true;
            }
            else if (targetPos == currentPos) {
                CancelMovement();
            }
            else {
                currentPos = targetPos;
                CancelMovement();
                gameObject.transform.position = new Vector3(currentPos.x, (int)currentLayer * ArenaManager.heightMultiplier, currentPos.y);
                //Movement has been used up
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isColored) {
            CancelMovement();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (IsValidMovementTile(currentLayer, moveRange, new Point(targetPos.x - 1, targetPos.y))) {
                Arena.Instance.HighlightTile(currentLayer, targetPos, Arena.highlightColor);
                targetPos.x -= 1;
                Arena.Instance.HighlightMovementTargetTile(currentLayer, targetPos);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (IsValidMovementTile(currentLayer, moveRange, new Point(targetPos.x + 1, targetPos.y))) {
                Arena.Instance.HighlightTile(currentLayer, targetPos, Arena.highlightColor);
                targetPos.x += 1;
                Arena.Instance.HighlightMovementTargetTile(currentLayer, targetPos);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (IsValidMovementTile(currentLayer, moveRange, new Point(targetPos.x, targetPos.y + 1))) {
                Arena.Instance.HighlightTile(currentLayer, targetPos, Arena.highlightColor);
                targetPos.y += 1;
                Arena.Instance.HighlightMovementTargetTile(currentLayer, targetPos);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (IsValidMovementTile(currentLayer, moveRange, new Point(targetPos.x, targetPos.y - 1))) {
                Arena.Instance.HighlightTile(currentLayer, targetPos, Arena.highlightColor);
                targetPos.y -= 1;
                Arena.Instance.HighlightMovementTargetTile(currentLayer, targetPos);
            }
        }
    }

    /*
     * IsValidTile
     * Creating a hash set of valid tiles would be faster, but for small range sizes it's not a big deal
     */ 
    bool IsValidMovementTile(int fl, int range, Point targetPos) {
        int absX = Mathf.Abs(targetPos.x - currentPos.x);
        int absY = Mathf.Abs(targetPos.y - currentPos.y);

        if (Arena.Instance.GetLayers()[fl].IsValidTile(targetPos.x, targetPos.y) && absX + absY <= range) {
            return true;
        }

        return false;
    }
    bool IsValidMovementTile(FloorLayers fl, int range, Point targetPos) {
        return IsValidMovementTile((int)fl, range, targetPos);
    }

    void CancelMovement() {
        Arena.Instance.ClearHighlights();
        isColored = false;
    }
}
