using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMenu : MonoBehaviour {

    public static TurnMenu instance;

    [SerializeField] GameObject panel;
    GameObject targetUnit;
    bool hasMoved;

    public void Awake() {
        instance = this;
    }

    public void Display() {
        panel.SetActive(true);
    }

    public void Hide() {
        panel.SetActive(false);
    }

    public void UnitSelected(GameObject currentUnit) {
        targetUnit = currentUnit;
        Display();
    }

    public void Move() {
        targetUnit.GetComponent<UnitMovement>().Enable();
        Hide();
    }

    public void EndTurn() {

    }
}
