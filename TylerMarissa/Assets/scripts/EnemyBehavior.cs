using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameManager gameManager;


    [SerializeField] private float rateOfFire = 3f;
    [SerializeField] private float accuracy;
    [SerializeField] private float enemyRange;
    //public float SpeedOfAmmo;

    //public GameObject EnemyAmmo;
    private EnemyAggroBehavior enemyAggro;
    public bool EnemyIsShooting = false;

    private Vector3 LaserAim;
    public LineRenderer LineRend;
    [SerializeField] LayerMask layersToIgnore;

    public bool HitByEle = false;
    public bool HitByWater = false;


    private void Awake()
    {
        enemyAggro = this.gameObject.transform.GetComponentInChildren<EnemyAggroBehavior>();
        gameManager = gameController.GetComponent<GameManager>();
    }

    private void Update()
    {
        if(HitByEle && HitByWater)
        {
            Destroy(gameObject);
            ++gameManager.EnemiesKilled;
        }
    }

    public IEnumerator Laser()
    {
        while(EnemyIsShooting)
        {
            LaserAim = enemyAggro.EnemyTarget;              //stores players current pos as where the enemy will aim
            LineRend.enabled = true;                        //turns laser on
            LineRend.SetPosition(0, transform.position);
            LineRend.SetPosition(1, LaserAim);
            Debug.Log("Aim");

            Invoke("EnemyShooting", 1);                     //waits one second to shoot
            //laser power up sound

            yield return new WaitForSeconds(rateOfFire);
        }
    }

    private void EnemyShooting()
    {
        LineRend.enabled = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, LaserAim, enemyRange, ~layersToIgnore);
        //Debug.Log(hit.collider.gameObject.name);
        if (hit) //.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            enemyAggro.Player.GetComponent<PlayerBehavior>().stunned = true;

            EnemyIsShooting = false;
        }
    }
}
