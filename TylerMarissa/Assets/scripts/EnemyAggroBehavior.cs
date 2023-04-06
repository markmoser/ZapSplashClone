using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroBehavior : MonoBehaviour
{
    public GameObject EnemyTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when the player enters the range of the enemy
        if (collision.gameObject.CompareTag("Player"))          //and if routine is not already running !!
        {
            print("Start EnemyShooting Coroutine");

            EnemyTarget = collision.gameObject;
            print(EnemyTarget);

            StartCoroutine(transform.parent.GetComponent<EnemyBehavior>().EnemyShooting());
        }
  
    }
}
