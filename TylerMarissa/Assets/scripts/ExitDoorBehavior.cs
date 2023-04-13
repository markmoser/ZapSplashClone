using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorBehavior : MonoBehaviour
{
    public void OpenDoor() {
        gameObject.SetActive(false);
    }
}
