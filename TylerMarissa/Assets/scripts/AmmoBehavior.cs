using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehavior : MonoBehaviour
{
    //ammo movement
    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, transform.GetComponent<EnemyAggroBehavior>().EnemyTarget, transform.parent.GetComponent<EnemyBehavior>().speedOfAmmo);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(5,5,0), 5f);
    }

    private void Awake()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.parent.GetComponentsInChildren<EnemyAggroBehavior>().EnemyTarget.transform.position * 1f);
    }

    //what happens when ammo hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerBehavior>().stunned = true;
            Destroy(this);
        }
        
    }
}
