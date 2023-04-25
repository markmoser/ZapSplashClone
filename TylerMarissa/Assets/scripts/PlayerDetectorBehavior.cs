using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectorBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private GameObject ClosestPlayer()
    {
        GameObject elePlayer = GameObject.Find("ElectricPlayer(Clone)");
        float elePlayerDistance = Mathf.Pow(Mathf.Abs(transform.position.x - elePlayer.transform.position.x), 2) +
                                  Mathf.Pow(Mathf.Abs(transform.position.y - elePlayer.transform.position.y), 2);
        elePlayerDistance = Mathf.Sqrt(elePlayerDistance);

        GameObject waterPlayer = GameObject.Find("WaterPlayer(Clone)");
        float waterPlayerDistance = Mathf.Pow(Mathf.Abs(transform.position.x - waterPlayer.transform.position.x), 2) +
                                  Mathf.Pow(Mathf.Abs(transform.position.y - waterPlayer.transform.position.y), 2);
        waterPlayerDistance = Mathf.Sqrt(waterPlayerDistance);
        if (elePlayerDistance < waterPlayerDistance)
        {
            return elePlayer;
        }
        return waterPlayer;
    }
}
