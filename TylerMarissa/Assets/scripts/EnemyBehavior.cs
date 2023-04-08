using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float rateOfFire;
    [SerializeField] private float accuracy;
    [SerializeField] private float ammoRange;
    public float SpeedOfAmmo;

    public GameObject EnemyAmmo;
    private EnemyAggroBehavior enemyAggro;
    public bool EnemyIsShooting = false;


    private void Awake()
    {
        enemyAggro = this.gameObject.transform.GetComponentInChildren<EnemyAggroBehavior>();
    }

    public IEnumerator EnemyShooting()
    {
        //Instantiate(EnemyAmmo, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        EnemyShoot();
        
        yield return new WaitForSeconds(rateOfFire);
    }
    
    void EnemyShoot()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, enemyAggro.EnemyTarget);
        if (raycast) //&& hit.transform.CompareTag("Player"))
        {
            //Debug.Log("hit");
        }
    }
    
}
