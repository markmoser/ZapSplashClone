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

public class WaterAmmoBehavior : MonoBehaviour
{
    [SerializeField] private float ammoSpeed;
    [SerializeField] private float ammoLifeTime = 3;

    private void Update()
    {
        transform.Translate(Vector3.up * ammoSpeed * Time.deltaTime);
        Invoke("DestroyAmmo", ammoLifeTime);
    }

    //what happens when ammo hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyBehavior>().HitByWater = true;
            //Destroy(gameObject);
        }
    }

    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
