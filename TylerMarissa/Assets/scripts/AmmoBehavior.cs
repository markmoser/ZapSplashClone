using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehavior : MonoBehaviour
{
    private PlayerBehavior playerScript;

    private void Awake()
    {
        playerScript = this.gameObject.transform.parent.GetComponent<PlayerBehavior>();
    }

    private void Update()
    {
        transform.Translate(Vector3.up * playerScript.ammoSpeed * Time.deltaTime);
        //destroy gameObject after time
    }

    //what happens when ammo hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //if the ammo is from the ele player
            if (playerScript.IsElePlayer)
            {
                collision.gameObject.GetComponent<EnemyBehavior>().HitByEle = true;
            }
            //if the player is hit by the water player
            if (!playerScript.IsElePlayer)
            {
                collision.gameObject.GetComponent<EnemyBehavior>().HitByWater = true;
            }
            Destroy(gameObject);
        }
    }
}
