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

public class CameraBehavior : MonoBehaviour
{
    public void MoveCamera(float xLoc, float yLoc) 
    {
        Vector3 newPos = new Vector3(xLoc, yLoc, -10);
        transform.position = newPos;
    }
}
