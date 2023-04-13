using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleAmmoBehavior : MonoBehaviour
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
            collision.gameObject.GetComponent<EnemyBehavior>().HitByEle = true;
            //Destroy(gameObject);
        }
    }

    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
