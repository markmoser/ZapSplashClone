using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerBehavior : MonoBehaviour
{
    public void FreePrisoner() {
        gameObject.SetActive(false);
        print("im free!!");
    }
}
