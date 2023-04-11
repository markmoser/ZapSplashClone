using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private bool toggled = false;
    private GameManager gm = GameObject.Find("GameControler").GetComponent<GameManager>();
    public void PressButton()
    {
        if (!toggled) {
            gm.countButton();
        }
        toggled = true;
    }
}
