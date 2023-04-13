/**********************************************************************************

// File Name :         GameManager.cs
// Author :            Marissa Moser
// Creation Date :     April 13, 2023
//
// Brief Description : Game Manager script used to keep track of the three goals
        and sliders, and the overall victory condition.

**********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ElePlayer;
    public GameObject WaterPlayer;
    public GameObject ExitDoor;

    public int buttonsPressed = 0;
    public int EnemiesKilled = 0;
    public int prisonersFreed = 0;

    public ExitDoorBehavior exitDoorScript;

    [SerializeField] private Slider enemiesKilledSlider;
    [SerializeField] private Slider buttonsPressedSlider;
    [SerializeField] private Slider npcsFreedSlider;

    /// <summary>
    /// Manually spawns in players upon start. Also sets Refrences to their
    ///     coresponding asset.
    /// </summary>
    void Start()
    {
        PlayerInput.Instantiate(ElePlayer, 0, null, pairWithDevice: Gamepad.all[0]);
        PlayerInput.Instantiate(WaterPlayer, 1, null, pairWithDevice: Gamepad.all[1]);//comment out this line to test with 1 player
        //Instantiate(WaterPlayer);//uncomment this line to test with 1 player

        ExitDoor = GameObject.Find("ExitDoor");
        exitDoorScript = ExitDoor.GetComponent<ExitDoorBehavior>();
    }

    /// <summary>
    /// Upsate function updates the sliders and checks for the end/victory condition.
    /// </summary>
    private void Update()
    {
        enemiesKilledSlider.value = EnemiesKilled;
        buttonsPressedSlider.value = buttonsPressed;
        npcsFreedSlider.value = prisonersFreed;

        if (prisonersFreed >= 8 && buttonsPressed >= 4) // && EnemiesKilled >= 0) 
        {
            exitDoorScript.OpenDoor();
        }
    }

    /// <summary>
    /// Called from other sctipts to update the count.
    /// </summary>
    public void CountButton()
    {
        buttonsPressed++;
    }
    /// <summary>
    /// Called from other sctipts to update the count.
    /// </summary>
    public void CountPrisoner()
    {
        prisonersFreed++;
    }
    /// <summary>
    /// Called from other sctipts to update the count.
    /// </summary>
    public void CountEnemy()
    {
        EnemiesKilled++;
    }
}
