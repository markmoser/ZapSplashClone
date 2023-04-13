/**********************************************************************************

// File Name :         WaterAmmoBehavior.cs
// Author :            Marissa Moser
// Creation Date :     April 13, 2023
//
// Brief Description : Code for the Water player's ammo. It moves and destroys
        the ammo, and does "damage" when it hist the enemy.

**********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAmmoBehavior : MonoBehaviour
{
    [SerializeField] private float ammoSpeed;
    [SerializeField] private float ammoLifeTime = 3;

    /// <summary>
    /// Update functoin moves the player's ammo and calls the destroy function 
    ///     after the ammoLifeTime float's amount of time.
    /// </summary>
    private void Update()
    {
        transform.Translate(Vector3.up * ammoSpeed * Time.deltaTime);
        Invoke("DestroyAmmo", ammoLifeTime);
    }

    /// <summary>
    /// what happens when ammo hits something
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyBehavior>().HitByWater = true;
            //Destroy(gameObject);
        }
    }

    /// <summary>
    /// Function called to destroy the ammo
    /// </summary>
    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
