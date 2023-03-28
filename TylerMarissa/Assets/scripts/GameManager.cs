using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject ElePlayer;
    public GameObject WaterPlayer;
    //public PlayerInputManager pIM;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInput.Instantiate(ElePlayer, -1, null, -1, pairWithDevice: Gamepad.all[-1]);
        PlayerInput.Instantiate(WaterPlayer, -1, null, -1, pairWithDevice: Gamepad.all[-1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
