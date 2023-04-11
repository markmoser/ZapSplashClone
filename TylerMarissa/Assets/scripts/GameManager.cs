using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject ElePlayer;
    public GameObject WaterPlayer;
    //public PlayerInputManager pIM;


    void Start()
    {
        PlayerInput.Instantiate(ElePlayer, 0, null, pairWithDevice: Gamepad.all[0]);
        //PlayerInput.Instantiate(WaterPlayer, 1, null, pairWithDevice: Gamepad.all[1]);
    }
}
