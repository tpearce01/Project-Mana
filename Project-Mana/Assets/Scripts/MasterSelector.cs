using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSelector : MonoBehaviour {

    public static MasterSelector instance;

    [SerializeField] Point currentPos;
    [SerializeField] FloorLayers currentLayer;
    bool isActive = true;
    GameObject currentUnit;
    bool activatedThisFrame = false;

    void Awake() {
        instance = this;
    }

    void Start() {
        Show(currentPos);
    }

    void Update() {
        if (isActive) {
            if (!activatedThisFrame) {
                Controls();
            }
            else {
                activatedThisFrame = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) {
            //Deselect unit and re-enable master selector
            currentUnit.GetComponent<UnitMovement>().Disable();
            currentUnit = null;
        }
    }

    public void Show(Point pos) {
        currentPos = new Point(pos.x, pos.y);
        isActive = true;
        Arena.Instance.HighlightTile(currentLayer, currentPos, Arena.masterSelectorColor);
        currentUnit = null;
        activatedThisFrame = true;
    }

    public void Hide(Color c) {
        Arena.Instance.HighlightTile(currentLayer, currentPos, c);
        isActive = false;
    }

    //Could be improved
    public GameObject GetUnitAtPos(Point pos) {
        GameObject[] units = TurnSystemManager.instance.GetUnitList();
        for (int i = 0; i < units.Length; i++) {
            if (units[i].GetComponent<UnitMovement>().GetPosition().x == pos.x && units[i].GetComponent<UnitMovement>().GetPosition().y == pos.y) {
                return units[i];
            }
        }
        return null;
    }

    void Controls() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            currentUnit = GetUnitAtPos(currentPos);
            if (currentUnit != null && !currentUnit.GetComponent<UnitMovement>().hasMoved) {
                Hide(Arena.targetMovementColor);
                //currentUnit.GetComponent<UnitMovement>().Enable();
                TurnMenu.instance.UnitSelected(currentUnit);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (IsValidMovementTile(currentLayer, new Point(currentPos.x - 1, currentPos.y))) {
                Arena.Instance.HighlightTile(currentLayer, currentPos, Arena.defaultColor);
                currentPos.x -= 1;
                Arena.Instance.HighlightTile(currentLayer, currentPos, Arena.masterSelectorColor);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (IsValidMovementTile(currentLayer, new Point(currentPos.x + 1, currentPos.y))) {
                Arena.Instance.HighlightTile(currentLayer, currentPos, Arena.defaultColor);
                currentPos.x += 1;
                Arena.Instance.HighlightTile(currentLayer, currentPos, Arena.masterSelectorColor);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (IsValidMovementTile(currentLayer, new Point(currentPos.x, currentPos.y + 1))) {
                Arena.Instance.HighlightTile(currentLayer, currentPos, Arena.defaultColor);
                currentPos.y += 1;
                Arena.Instance.HighlightTile(currentLayer, currentPos, Arena.masterSelectorColor);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (IsValidMovementTile(currentLayer, new Point(currentPos.x, currentPos.y - 1))) {
                Arena.Instance.HighlightTile(currentLayer, currentPos, Arena.defaultColor);
                currentPos.y -= 1;
                Arena.Instance.HighlightTile(currentLayer, currentPos, Arena.masterSelectorColor);
            }
        }
    }

    /*
     * IsValidTile
     * Creating a hash set of valid tiles would be faster, but for small range sizes it's not a big deal
     */
    bool IsValidMovementTile(int fl, Point targetPos) {
        if (Arena.Instance.GetLayers()[fl].IsValidTile(targetPos.x, targetPos.y)) {
            return true;
        }
        return false;
    }
    bool IsValidMovementTile(FloorLayers fl, Point targetPos) {
        return IsValidMovementTile((int)fl, targetPos);
    }

    void CancelMovement() {
        Arena.Instance.ClearHighlights();
    }

    public void SetActive(bool b) {
        isActive = b;
    }
}
