using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroBehavior : MonoBehaviour
{
    public Vector3 EnemyTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when the player enters the range of the enemy
        if (collision.gameObject.CompareTag("Player"))          //and if routine is not already running !!
        {
            EnemyTarget = collision.gameObject.transform.position;
            //print(EnemyTarget);
            //print(transform.parent.GetComponent<EnemyBehavior>());
            StartCoroutine(transform.parent.GetComponent<EnemyBehavior>().EnemyShooting());
        }
  
    }
}
