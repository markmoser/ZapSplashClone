/**********************************************************************************

// File Name :         EnemyBehavior.cs
// Author :            Marissa Moser
// Creation Date :     April 13, 2023
//
// Brief Description : Code for the enemies. 

**********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    private GameManager gameManager;

    [SerializeField] private float rateOfFire = 3f;
    [SerializeField] private float accuracy;
    [SerializeField] private float enemyRange = 50;
    //public float SpeedOfAmmo;

    //public GameObject EnemyAmmo;
    private EnemyAggroBehavior enemyAggro;
    public bool EnemyIsShooting = false;

    private Vector3 LaserAim;
    public LineRenderer LineRend;
    [SerializeField] LayerMask layersToIgnore;

    public bool HitByEle = false;
    public bool HitByWater = false;

    /// <summary>
    /// Sets Refrences to their coresponding asset
    /// </summary>
    private void Awake()
    {
        enemyAggro = this.gameObject.transform.GetComponentInChildren<EnemyAggroBehavior>();
        gameManager = gameController.GetComponent<GameManager>();

        enemyRange = 50f;
    }

    //Update function checks for the enemy's death state
    private void Update()
    {
        if(HitByEle && HitByWater)
        {
            Destroy(gameObject);
            gameManager.CountEnemy();
        }
    }

    /// <summary>
    /// Coroutine for the enemies laser. Uses a line renderer to simulate the
    ///     laser, and then calls the Shooting function after 1 second.
    /// </summary>
    public IEnumerator Laser()
    {
        while(EnemyIsShooting)
        {
            LaserAim = enemyAggro.EnemyTarget;              //stores players current pos as where the enemy will aim
            LineRend.enabled = true;                        //turns laser on, want to fade it in using alpha?
            LineRend.SetPosition(0, transform.position);
            LineRend.SetPosition(1, LaserAim);
            //Debug.Log("Aim");

            Invoke("EnemyShooting", 1);                     //waits one second to shoot
            //laser power up sound

            yield return new WaitForSeconds(rateOfFire);
        }
    }

    /// <summary>
    /// Funcion called from the Laser Coroutine. Contains the raycast functionality
    ///     and stunnd the player on hit.
    /// </summary>
    private void EnemyShooting()
    {
        LineRend.enabled = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, LaserAim, enemyRange, ~layersToIgnore);
        //Debug.Log(hit);
        //enemyAggro.EnemyTarget == LaserAim
        if (hit)
        {
            //Debug.Log("was hit");
            //Debug.Log(hit.collider.gameObject.transform.parent.name);
            //do not delete this debug
            //hit.collider.gameObject.transform.parent.GetComponent<PlayerBehavior>().stunned = true;
            EnemyIsShooting = false;
        }
    }
}
