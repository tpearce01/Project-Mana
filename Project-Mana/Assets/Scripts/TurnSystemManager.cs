using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 To Do List:
    1) Sort units to determine turn order
*/

public class TurnSystemManager : MonoBehaviour {
    private static TurnSystemManager instance;      // Singleton Reference
    static GameObject[] units;//Units in game scene
    static int currentUnit = 0;                            //Index of currently selected unit

    //Set default active player to 0
    void Start() {
        GetUnitsInScene();
        InitiateTurn();
    }

    /// <summary>
    /// Change active unit
    /// </summary>
    /// <param name="unit"></param>
    static void SetActiveUnit(int unit) {
        //Set current Unit scripts to be inactive

        if (units.Length > currentUnit) {
            units[currentUnit].GetComponent<UnitMovement>().SetActive(false);
        }

        //Set new current Unit
        currentUnit = unit;

        //Set current Unit scripts to be active
        if (units.Length > currentUnit) {
            units[currentUnit].GetComponent<UnitMovement>().SetActive(true);
        }
    }

    /// <summary>
    /// Populate the unit array
    /// </summary>
    void GetUnitsInScene() {
        units = GameObject.FindGameObjectsWithTag("Unit");
        //units.AddRange(GameObject.FindGameObjectsWithTag("Unit"));
    }

    /// <summary>
    /// Changes the turn to the next unit
    /// </summary>
    public static void ActivateNextUnit() {
        Debug.Log("Changing unit to " + (currentUnit + 1) + " out of " + units.Length + " units.");
        if (currentUnit + 1 >= units.Length) {
            Debug.Log("All units moved.");
            AllUnitsMoved();
            return;
        }
        SetActiveUnit((currentUnit + 1));
    }

    static void AllUnitsMoved() {
        units[currentUnit].GetComponent<UnitMovement>().SetActive(false);
        //Trigger next event
        InitiateTurn();    //For testing
    }

    static void InitiateTurn() {
        Debug.Log("Turn Begin.");
        if (units.Length > 0) {
            SetActiveUnit(0);
        }
    }
}
