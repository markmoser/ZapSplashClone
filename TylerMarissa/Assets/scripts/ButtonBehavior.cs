/**********************************************************************************

// File Name :         ButtonBehavior.cs
// Author :            Tyler Bouchard
// Creation Date :     April 13, 2023
//
// Brief Description : determines when and if a buttton is pressed

**********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private bool toggled = false;

    [SerializeField] private Animator anim;
    [SerializeField] private GameObject gameController;


    public void PressButton()
    {
        if (!toggled) 
        {
            gameController.GetComponent<GameManager>().CountButton();
            anim.SetBool("isToggled", true);
            FindObjectOfType<AudioManager>().Play("buttonOff");
        }
        toggled = true;
    }
}
