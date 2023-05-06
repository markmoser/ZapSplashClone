/**********************************************************************************

// File Name :         AmmoBehavior.cs
// Author :            Marissa Moser
// Creation Date :     April 13, 2023
//
// Brief Description : Code for the player's ammo. It moves and destroys
        the ammo, and does "damage" when it hist the enemy.

**********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehavior : MonoBehaviour
{
    [SerializeField] private float ammoSpeed;
    [SerializeField] private bool isElePlayer = true;
    [SerializeField] private bool isEnemy = false;

    /// <summary>
    /// Update functoin moves the player's ammo and calls the destroy function 
    ///     after the ammoLifeTime float's amount of time.
    /// </summary>
    private void Update()
    {
        transform.Translate(Vector3.up * ammoSpeed * Time.deltaTime);
    }

    /// <summary>
    /// what happens when ammo hits something
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isElePlayer)
        {
            collision.gameObject.GetComponent<Enemy2Behavior>().HitByEle = true;
        }
        else if(collision.gameObject.tag == "Enemy" && !isElePlayer)
        {
            collision.gameObject.GetComponent<Enemy2Behavior>().HitByWater = true;
        }
        if (isEnemy) {
            Destroy(gameObject);
        }
        if (isElePlayer && !(collision.gameObject.name == "ElectricPlayer(Clone)")) {
            Destroy(gameObject);
        }
        if (!isElePlayer && !(collision.gameObject.name == "WaterPlayer(Clone)"))
        {
            Destroy(gameObject);
        }
        
    }
}
