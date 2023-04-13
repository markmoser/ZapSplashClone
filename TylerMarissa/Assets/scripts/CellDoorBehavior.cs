using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDoorBehavior : MonoBehaviour
{
    public void OpenDoor() {
        gameObject.SetActive(false);
    }
}
