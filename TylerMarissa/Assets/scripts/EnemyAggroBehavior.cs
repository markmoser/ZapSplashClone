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

public class EnemyAggroBehavior : MonoBehaviour
{
    public Vector3 EnemyTarget;
    private EnemyBehavior enemy;
    public GameObject Player;

    private void Awake()
    {
        enemy = this.gameObject.transform.parent.GetComponent<EnemyBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when the player enters the range of the enemy and enemy is not already shooting
        if (collision.gameObject.CompareTag("Player") && !enemy.EnemyIsShooting)   
        {
            enemy.EnemyIsShooting = true;
            Player = collision.gameObject;
            StartCoroutine(enemy.Laser());
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //when the player is in range the range of the enemy
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyTarget = collision.gameObject.transform.position;

            enemy.EnemyIsShooting = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(enemy.Laser());
        enemy.EnemyIsShooting = false;
        enemy.LineRend.enabled = false;
    }
}
