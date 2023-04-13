using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ElePlayer;
    public GameObject WaterPlayer;
    //public PlayerInputManager pIM;
    [SerializeField] private GameObject buttonText;
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
        print("Buttons: " + buttonsPressed + "/4");
        buttonText.GetComponent<Text>().text = "Buttons: " + buttonsPressed + "/4";
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
