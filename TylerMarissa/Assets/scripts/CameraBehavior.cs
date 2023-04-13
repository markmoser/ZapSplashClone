/**********************************************************************************

// File Name :         CameraBehavior.cs
// Author :            Tyler Bouchard
// Creation Date :     April 13, 2023
//
// Brief Description : moves the Camera

**********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public void MoveCamera(float xLoc, float yLoc) 
    {
        Vector3 newPos = new Vector3(xLoc, yLoc, -10);
        transform.position = newPos;
    }
}
