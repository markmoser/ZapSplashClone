/**********************************************************************************

// File Name :         Assignment2.cs
// Author :            Marissa Moser
// Creation Date :     January 31, 2023
//
// Brief Description : Code for Assignment2, reversing an integer using modulos and
                          converting a distance from miles to kilometers.

**********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    private PlayerBehavior playerScript;
    private CameraBehavior camScript;
    private Vector2 doorLocation, targetLoc1, targetLoc2;

    [SerializeField] private float targetLoc1x = 0, targetLoc1y = 0;
    [SerializeField] private float targetLoc2x = 0, targetLoc2y = 0;
    [SerializeField] private float CamTargetLocX = 0, CamTargetLocY = 0;
    private void Start(){
        doorLocation = new Vector2(transform.position.x, transform.position.y);
        targetLoc1 = new Vector2(targetLoc1x, targetLoc1y);
        targetLoc2 = new Vector2(targetLoc2x, targetLoc2y);
        camScript = GameObject.Find("Main Camera").GetComponent<CameraBehavior>();
    }
    public void GoThroughDoor(GameObject player, GameObject otherPlayer) {
        playerScript = player.GetComponent<PlayerBehavior>();
        playerScript.MovePlayer(targetLoc1);
        print(otherPlayer);
        playerScript = otherPlayer.GetComponent<PlayerBehavior>();
        
        playerScript.MovePlayer(targetLoc2);
        camScript.MoveCamera(20f * CamTargetLocX, 12f * CamTargetLocY);
    }
}
