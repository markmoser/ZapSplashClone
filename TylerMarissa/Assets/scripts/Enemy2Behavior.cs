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
        GameObject player = GameObject.Find("ElectricPlayer(Clone)");
        PointTowardsPlayer(player);
    }
    IEnumerator Shooting() {
        while (true) {
            RaycastHit2D hit = Physics2D.Raycast(rayStart.transform.position, transform.TransformDirection(Vector2.up), 100f);
            if (hit.collider.name == "WaterPlayer(Clone)" || hit.collider.name == "ElectricPlayer(Clone)") {
                Instantiate(ammo, ammoSpawn.transform.position, transform.rotation);
            }
            print(hit.collider.name);
            yield return new WaitForSeconds(fireRate);
        }
    }
    private void PointTowardsPlayer(GameObject player) {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 270f;
        Quaternion ang = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, ang, Time.deltaTime * turnSpeed);
    }
}
