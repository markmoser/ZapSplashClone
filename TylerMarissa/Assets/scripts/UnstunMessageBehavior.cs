using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstunMessageBehavior : MonoBehaviour
{
    public void Update()
    {
        if (GameObject.Find("WaterPlayer(Clone)").GetComponent<PlayerBehavior>().stunned ||
            GameObject.Find("ElectricPlayer(Clone)").GetComponent<PlayerBehavior>().stunned)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }
}
