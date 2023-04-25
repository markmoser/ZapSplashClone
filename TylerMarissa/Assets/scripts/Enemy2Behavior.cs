using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy2Behavior : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    private GameManager gameManager;

    public bool HitByEle = false;
    public bool HitByWater = false;
    [SerializeField] private GameObject ammo;
    [SerializeField] private GameObject ammoSpawn;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private GameObject rayStart;
    [SerializeField] private float detectionRadius = 100f;
    private bool eleHiding, waterHiding;
    /// <summary>
    /// Sets Refrences to their coresponding asset
    /// </summary>
    private void Start()
    {
        gameManager = gameController.GetComponent<GameManager>();
        StartCoroutine(Shooting());
    }

    //Update function checks for the enemy's death state
    private void Update()
    {
        if (HitByEle && HitByWater)
        {
            Destroy(gameObject);
            gameManager.CountEnemy();
        }
        //figure out the best way to detect closest player :)
        PointTowardsPlayer(ClosestPlayer());
    }
    IEnumerator Shooting() {
        while (true) {
            RaycastHit2D hit = Physics2D.Raycast(rayStart.transform.position, transform.TransformDirection(Vector2.up), detectionRadius);
            if (hit.collider.tag == "Player")
            {
                Instantiate(ammo, ammoSpawn.transform.position, transform.rotation);
            }
            //print(hit.collider.name);
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
    private GameObject ClosestPlayer() {
        GameObject elePlayer = GameObject.Find("ElectricPlayer(Clone)");
        float elePlayerDistance = Mathf.Pow(Mathf.Abs(transform.position.x - elePlayer.transform.position.x), 2) +
                                  Mathf.Pow(Mathf.Abs(transform.position.y - elePlayer.transform.position.y), 2);
        elePlayerDistance = Mathf.Sqrt(elePlayerDistance);

        GameObject waterPlayer = GameObject.Find("WaterPlayer(Clone)");
        float waterPlayerDistance = Mathf.Pow(Mathf.Abs(transform.position.x - waterPlayer.transform.position.x), 2) +
                                    Mathf.Pow(Mathf.Abs(transform.position.y - waterPlayer.transform.position.y), 2);
        waterPlayerDistance = Mathf.Sqrt(waterPlayerDistance);
        if (elePlayerDistance < waterPlayerDistance)
        {
            return elePlayer;
        }
        return waterPlayer;
    }
}
