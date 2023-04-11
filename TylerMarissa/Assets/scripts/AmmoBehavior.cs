using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehavior : MonoBehaviour
{
    private EnemyAggroBehavior enemyAggro;
    private EnemyBehavior enemy;

    private void Awake()
    {
        enemyAggro = this.gameObject.transform.parent.GetComponentInChildren<EnemyAggroBehavior>();
        enemy = this.gameObject.transform.parent.GetComponent<EnemyBehavior>();
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, enemyAggro.EnemyTarget, 0.05f);
        gameObject.GetComponent<Rigidbody2D>().AddForce(enemyAggro.EnemyTarget * 5f);
    }

    //what happens when ammo hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerBehavior>().stunned = true;
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
