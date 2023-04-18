/**********************************************************************************

// File Name :         EnemyAggroBehavior.cs
// Author :            Marissa Moser
// Creation Date :     April 13, 2023
//
// Brief Description : Code for the enemies "wake up" range. When the player
        enters the trigger this script is attatched to, it calls the laser
        from it's parent enemy script.

**********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroBehavior : MonoBehaviour
{
    public Vector3 EnemyTarget;
    private EnemyBehavior enemy;
    public GameObject Player;

    /// <summary>
    /// Sets Refrences to their coresponding asset
    /// </summary>
    private void Awake()
    {
        enemy = this.gameObject.transform.parent.GetComponent<EnemyBehavior>();
    }

    /// <summary>
    /// On Trigger function called when the player enters the range of the enemy
    ///     and enemy is not already shooting
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !enemy.EnemyIsShooting)   
        {
            enemy.EnemyIsShooting = true;
            Player = collision.gameObject;
            EnemyTarget = collision.gameObject.transform.position;
            StartCoroutine(enemy.Laser());
        }

    }

    /// <summary>
    /// On trigger function called when player is currently in the enemy's range.
    ///     Sets the player's position to EnemyTarget for the Enemy Script
    /// </summary>
    private void OnTriggerStay2D(Collider2D collision)
    {
        //when the player is in range the range of the enemy
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyTarget = collision.gameObject.transform.position;

            enemy.EnemyIsShooting = true;
        }

    }

    /// <summary>
    /// On trigger function called when player leaves the enemy's range. The 
    ///     coroutine is stopped and the laser is turned off.
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(enemy.Laser());
        enemy.EnemyIsShooting = false;
        enemy.LineRend.enabled = false;
    }
}
