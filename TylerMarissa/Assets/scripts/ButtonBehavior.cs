/**********************************************************************************

// File Name :         Assignment2.cs
// Author :            Marissa Moser
// Creation Date :     January 31, 2023
//
// Brief Description : Code for Assignment2, reversing an integer using modulos and
                          converting a distance from miles to kilometers.

**********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private bool toggled = false;

    [SerializeField] private GameObject gameController;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = gameController.GetComponent<GameManager>();
    }

    public void PressButton()
    {
        if (!toggled) 
        {
            gameManager.CountButton();
        }
        toggled = true;
    }
}
