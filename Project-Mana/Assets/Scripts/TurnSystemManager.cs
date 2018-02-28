using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 To Do List:
    1) Sort units to determine turn order
*/

public class TurnSystemManager : MonoBehaviour {
    public static TurnSystemManager instance;      // Singleton Reference
    public static GameObject[] units;               //Units in game scene
    public static bool[] hasMoved;
    static int currentUnit = 0;                     //Index of currently selected unit

    public Material inactiveMaterial;
    public Material defaultMaterial;


    void Awake() {
        instance = this;
    }

    //Set default active player to 0
    void Start() {
        GetUnitsInScene();
    }

    /// <summary>
    /// Populate the unit array
    /// </summary>
    void GetUnitsInScene() {
        units = GameObject.FindGameObjectsWithTag("Unit");
    }

    GameObject[] GetUpdatedUnitList(GameObject[] list) {
        List<GameObject> returnList = new List<GameObject>();
        for (int i = 0; i < list.Length; i++) {
            if (list[i] != null) {
                returnList.Add(list[i]);
            }
        }
        return returnList.ToArray();
    }

    public GameObject[] GetUnitList() {
        return GetUpdatedUnitList(units);
    }

    public void CheckTurnEnd() {
        for (int i = 0; i < units.Length; i++) {
            if (!units[i].GetComponent<UnitMovement>().hasMoved) {
                return;
            }
        }
        RefreshTurn();
    }

    public void RefreshTurn() {
        Debug.Log("Refreshing turn...");
        for (int i = 0; i < units.Length; i++) {
            units[i].GetComponent<UnitMovement>().hasMoved = false;
            units[i].GetComponentInChildren<MeshRenderer>().materials[0] = defaultMaterial;
        }
    }
}
