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
    public LineRenderer LineRend;
    [SerializeField] LayerMask layersToHit;


    private void Awake()
    {
        enemyAggro = this.gameObject.transform.GetComponentInChildren<EnemyAggroBehavior>();
    }

    public IEnumerator Laser()
    {
        while(EnemyIsShooting)
        {
            LaserAim = enemyAggro.EnemyTarget;
            LineRend.enabled = true;
            LineRend.SetPosition(0, transform.position);
            LineRend.SetPosition(1, LaserAim);
            //Debug.Log("Aim");

            Invoke("EnemyShooting", 1);
            //laser power up sound

            yield return new WaitForSeconds(rateOfFire);
        }
    }

    private void EnemyShooting()
    {
        LineRend.enabled = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, LaserAim, enemyRange, layersToHit);
        //Debug.DrawRay(transform.position, LaserAim, Color.black, 10f);
        //Debug.Log(hit.collider.gameObject.name);
        if (hit) //.collider.gameObject.CompareTag("Player"))
        {
            //Debug.Log("hit");
            enemyAggro.Player.GetComponent<PlayerBehavior>().stunned = true;

            EnemyIsShooting = false;
        }
    }
}
