/**********************************************************************************

// File Name :         Assignment2.cs
// Author :            Marissa Moser
// Creation Date :     January 31, 2023
//
// Brief Description : Code for Assignment2, reversing an integer using modulos and
                          converting a distance from miles to kilometers.

**********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDoorBehavior : MonoBehaviour
{
    [SerializeField] private GameObject NPCinCell;
    private PrisonerBehavior prisonerScript;
    public void OpenDoor() {
        gameObject.SetActive(false);
        prisonerScript = NPCinCell.GetComponent<PrisonerBehavior>();
        prisonerScript.FreePrisoner();
    }
}
