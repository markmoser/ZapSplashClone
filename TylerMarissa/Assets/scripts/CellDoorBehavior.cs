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
