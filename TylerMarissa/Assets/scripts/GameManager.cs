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

    private int buttonsPressed = 0;
    public int EnemiesKilled = 0;
    private int prisonersFreed = 0;

    [SerializeField] private Slider enemiesKilledSlider;
    void Start()
    {
        PlayerInput.Instantiate(ElePlayer, 0, null, pairWithDevice: Gamepad.all[0]);
        //PlayerInput.Instantiate(WaterPlayer, 1, null, pairWithDevice: Gamepad.all[1]);
    }

    private void Update()
    {
        enemiesKilledSlider.value = EnemiesKilled;
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
