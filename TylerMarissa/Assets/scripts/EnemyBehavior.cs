using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float rateOfFire;
    [SerializeField] private float accuracy;
    public float speedOfAmmo;

    public GameObject EnemyAmmo;

   

    public IEnumerator EnemyShooting()
    {
        Instantiate(EnemyAmmo, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        
        
        yield return new WaitForSeconds(rateOfFire);
    }
}
