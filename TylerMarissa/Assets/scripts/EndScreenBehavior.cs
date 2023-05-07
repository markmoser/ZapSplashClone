/**********************************************************************************

// File Name :         MainMenuBehavior.cs
// Author :            Marissa Moser
// Creation Date :     April 13, 2023
//
// Brief Description : Code for the main menu. Adds functions for the two buttons,
       play and quit, and sets the play button to be selected first.

**********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EndScreenBehavior : MonoBehaviour
{
    public GameObject PlayButton;

    /// <summary>
    /// Begins the game
    /// </summary>
    public void StartLevel()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Start Level");
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    /// <summary>
    /// returns to main menu
    /// </summary>
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Start function is used to set the buttoon that will be selected first.
    /// </summary>
    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(PlayButton);
    }
}