using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private bool toggled = false;

    [SerializeField] private GameObject gameController;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = gameController.GetComponent<GameManager>();
    }

    public void PressButton()
    {
        if (!toggled) 
        {
            gameManager.CountButton();
        }
        toggled = true;
    }
}
