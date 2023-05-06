using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public int ammoEasterEggCount = 0;
    private GameObject ene;
    private void Start()
    {
        ene = GameObject.Find("Enemies");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EleAmmo(Clone)" && ammoEasterEggCount < 10)
        {
            ammoEasterEggCount++;
        }
        else if (collision.gameObject.name == "WaterAmmo(Clone)" && ammoEasterEggCount >= 10)
        {
            ammoEasterEggCount++;
        }else{
            ammoEasterEggCount = 0;
        }
        if (ammoEasterEggCount >= 20) {
            ene.SetActive(false);
            GameObject.Find("GameController").GetComponent<GameManager>().EnemiesKilled += 42;
        }
    }
}
