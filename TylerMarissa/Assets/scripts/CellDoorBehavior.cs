/**********************************************************************************

// File Name :         CellDoorBehavior.cs
// Author :            Tyler Bouchard
// Creation Date :     April 13, 2023
//
// Brief Description : allows the cell door to open

**********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDoorBehavior : MonoBehaviour
{
    [SerializeField] private GameObject NPCinCell;
    [SerializeField] private Animator anim;

    private PrisonerBehavior prisonerScript;

    public void OpenDoor() 
    {
        //gameObject.SetActive(false);
        anim.SetBool("DoorOpen", true);
        if(gameObject.GetComponent<BoxCollider2D>().enabled)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = !gameObject.GetComponent<BoxCollider2D>().enabled;
            prisonerScript = NPCinCell.GetComponent<PrisonerBehavior>();
            prisonerScript.FreePrisoner();
        }
    }
}
