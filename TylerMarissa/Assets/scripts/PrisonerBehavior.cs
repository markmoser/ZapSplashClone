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

public class PrisonerBehavior : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager gameManagerScript;
    public void Start()
    {
        gameManager = GameObject.Find("GameController");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    public void FreePrisoner() {
        gameObject.SetActive(false);
        print("im free!!");
        gameManagerScript.prisonersFreed++;
    }
}
