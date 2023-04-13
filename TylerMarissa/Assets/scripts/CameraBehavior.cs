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
