using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float rateOfFire;
    [SerializeField] private float accuracy;
    [SerializeField] private float enemyRange;
    //public float SpeedOfAmmo;

    //public GameObject EnemyAmmo;
    private EnemyAggroBehavior enemyAggro;
    public bool EnemyIsShooting = false;

    private Vector3 LaserAim;
    [SerializeField] LineRenderer lineRend;


    private void Awake()
    {
        enemyAggro = this.gameObject.transform.GetComponentInChildren<EnemyAggroBehavior>();
    }

    public IEnumerator Laser()
    {
        while(EnemyIsShooting)
        {
            LaserAim = enemyAggro.EnemyTarget;
            lineRend.enabled = true;
            lineRend.SetPosition(0, transform.position);
            lineRend.SetPosition(1, LaserAim);
            Debug.Log("Aim");

            Invoke("EnemyShooting", 1);
            //laser power up sound

            yield return new WaitForSeconds(rateOfFire);
        }
    }

    private void EnemyShooting()
    {
        Debug.Log("enemy shooting");

        RaycastHit2D raycast = Physics2D.Raycast(transform.position, LaserAim, enemyRange);
        if (raycast && enemyAggro.Player.transform.CompareTag("Player"))
        {
            Debug.Log("hit");
            enemyAggro.Player.GetComponent<PlayerBehavior>().stunned = true;
            lineRend.enabled = false;
            StopCoroutine("Laser");
        }
    }
}
