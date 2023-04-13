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
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ElePlayer;
    public GameObject WaterPlayer;
    public GameObject ExitDoor;
    //public PlayerInputManager pIM;
    public int buttonsPressed = 0;
    public int EnemiesKilled = 0;
    public int prisonersFreed = 0;

    public ExitDoorBehavior exitDoorScript;

    [SerializeField] private Slider enemiesKilledSlider;
    [SerializeField] private Slider buttonsPressedSlider;
    [SerializeField] private Slider npcsFreedSlider;

    void Start()
    {
        PlayerInput.Instantiate(ElePlayer, 0, null, pairWithDevice: Gamepad.all[0]);
        //PlayerInput.Instantiate(WaterPlayer, 1, null, pairWithDevice: Gamepad.all[1]);//comment out this line to test with 1 player
        Instantiate(WaterPlayer);//uncomment this line to test with 1 player

        ExitDoor = GameObject.Find("ExitDoor");
        exitDoorScript = ExitDoor.GetComponent<ExitDoorBehavior>();
    }

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

    public void CountButton()
    {
        buttonsPressed++;
    }
    public void CountPrisoner()
    {
        prisonersFreed++;
    }
    public void CountEnemy()
    {
        EnemiesKilled++;
    }
}
