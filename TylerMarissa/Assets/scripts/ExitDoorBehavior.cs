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

public class ExitDoorBehavior : MonoBehaviour
{
    [SerializeField] private GameObject requirementsText;
    public void OpenDoor() {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player") {
            requirementsText.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            requirementsText.SetActive(false);
        }
    }
}
