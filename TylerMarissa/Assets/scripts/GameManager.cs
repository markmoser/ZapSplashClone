using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject ElePlayer;
    public GameObject WaterPlayer;
    //public PlayerInputManager pIM;

    private int buttonsPressed = 0;
    private int enemiesKilled = 0;
    private int prisonersFreed = 0;
    void Start()
    {
        PlayerInput.Instantiate(ElePlayer, 0, null, pairWithDevice: Gamepad.all[0]);
        //PlayerInput.Instantiate(WaterPlayer, 1, null, pairWithDevice: Gamepad.all[1]);
    }
    public void countButton()
    {
        buttonsPressed++;
    }
    public void countPrisoner()
    {
        prisonersFreed++;
    }
    public void countEnemy()
    {
        enemiesKilled++;
    }
}
