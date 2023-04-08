using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroBehavior : MonoBehaviour
{
    public Vector3 EnemyTarget;
    private EnemyBehavior enemy;


    private void Awake()
    {
        enemy = this.gameObject.transform.parent.GetComponent<EnemyBehavior>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //when the player enters the range of the enemy
        if (collision.gameObject.CompareTag("Player"))          //and if routine is not already running !!
        {
            EnemyTarget = collision.gameObject.transform.position;
            print(EnemyTarget);
            StartCoroutine(transform.parent.GetComponent<EnemyBehavior>().EnemyShooting());
        }
  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(transform.parent.GetComponent<EnemyBehavior>().EnemyShooting());
        enemy.EnemyIsShooting = false;
    }
}
