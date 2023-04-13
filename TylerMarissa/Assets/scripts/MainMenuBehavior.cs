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
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuBehavior : MonoBehaviour
{
    public GameObject PlayButton;

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Start Level");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(PlayButton);
    }
}
