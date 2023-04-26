using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy2Behavior : MonoBehaviour
{
    
    private GameManager gameManager;
    private EnemyEyeBehavior eyeScript;

    public bool HitByEle = false;
    public bool HitByWater = false;
   
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject ammo;
    [SerializeField] private GameObject ammoSpawn;
    [SerializeField] private GameObject eye;
    [SerializeField] private GameObject rayStart;
    [SerializeField] private GameObject puddle;
    [SerializeField] private GameObject sparks;


    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] public float detectionRadius = 100f;

    [SerializeField] public LayerMask layerToIgnore;

    /// <summary>
    /// Sets Refrences to their coresponding asset
    /// </summary>
    private void Start()
    {
        gameManager = gameController.GetComponent<GameManager>();
        eyeScript = eye.GetComponent<EnemyEyeBehavior>();
        StartCoroutine(Shooting());
    }

    //Update function checks for the enemy's death state
    private void Update()
    {
        if(HitByEle)
        {
            sparks.SetActive(true);
        }
        if(HitByWater)
        {
            puddle.SetActive(true);
        }

        if (HitByEle && HitByWater)
        {
            Destroy(gameObject);
            gameManager.CountEnemy();
        }

        PointTowardsPlayer(eyeScript.GetTargetPlayer());
    }
    IEnumerator Shooting() {
        while (true) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), detectionRadius, ~layerToIgnore);
            //print(hit.collider.name);
            if (hit.collider.tag == "Player")
            {
                Instantiate(ammo, ammoSpawn.transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(fireRate);
        }
    }
    private void PointTowardsPlayer(GameObject player)
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 270f;
        Quaternion ang = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, ang, Time.deltaTime * turnSpeed);
    }
}

