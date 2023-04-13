using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private bool toggled = false;
    private GameObject gm;
    private GameManager gmScript;
    public void Start() {
        gm = GameObject.Find("GameController");
        gmScript = gm.GetComponent<GameManager>();
    }
    public void PressButton()
    {
        if (!toggled) {
            gmScript.CountButton();
        }
        toggled = true;
    }
}
