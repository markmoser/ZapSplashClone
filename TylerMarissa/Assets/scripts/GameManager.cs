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
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//tinyChange.GitHub();
public class GameManager : MonoBehaviour
{
    public GameObject ElePlayer;
    public GameObject WaterPlayer;
    public GameObject ExitDoor;

    public int buttonsPressed = 0;
    public int EnemiesKilled = 0;
    public int prisonersFreed = 0;

    public bool elePlayerStunned = false;
    public bool waterPlayerStunned = false;

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
        PlayerInput.Instantiate(ElePlayer, 0, null, pairWithDevice: Gamepad.all[0]);        //spawns ele player
        PlayerInput.Instantiate(WaterPlayer, 1, null, pairWithDevice: Gamepad.all[1]);      //Use this line to use two controllers with two players
        //PlayerInput.Instantiate(WaterPlayer, 1, null, pairWithDevice: Gamepad.all[0]);      //Use this line with the first to spawn two players under the same controller

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

        if (prisonersFreed >= 8 && buttonsPressed >= 5 && EnemiesKilled >= 42)
        {
            exitDoorScript.OpenDoor();
        }
        PlayerBehavior elePlayerScript = GameObject.Find("ElectricPlayer(Clone)").GetComponent<PlayerBehavior>();
        PlayerBehavior waterPlayerScript = GameObject.Find("WaterPlayer(Clone)").GetComponent<PlayerBehavior>();
        print(elePlayerScript.stunned + " " + waterPlayerScript.stunned);
        if (elePlayerScript.stunned && waterPlayerScript.stunned) {
            SceneManager.LoadScene(3);
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
