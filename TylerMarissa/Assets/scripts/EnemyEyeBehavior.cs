using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyeBehavior : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private Enemy2Behavior enemyScript;
    void Start()
    {
        enemyScript = enemy.GetComponent<Enemy2Behavior>();
    }
    private void Update()
    {
        PointTowardsPlayer(ClosestPlayer(1));
    }
    /// <summary>
    /// points towards the target player
    /// </summary>
    /// <param name="player"></param>
    private void PointTowardsPlayer(GameObject player)
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 270f;
        Quaternion ang = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = ang;
    }
    /// <summary>
    /// returns the a player depending on its order from closest to furthese
    /// </summary>
    /// <param name="order"></param> 1 = first closest 2 = second and so on
    /// <returns></returns>
    private GameObject ClosestPlayer(int order)
    {
        GameObject elePlayer = GameObject.Find("ElectricPlayer(Clone)");
        float elePlayerDistance = Mathf.Pow(Mathf.Abs(transform.position.x - elePlayer.transform.position.x), 2) + 
                                  Mathf.Pow(Mathf.Abs(transform.position.y - elePlayer.transform.position.y), 2);
        elePlayerDistance = Mathf.Sqrt(elePlayerDistance);

        GameObject waterPlayer = GameObject.Find("WaterPlayer(Clone)");
        float waterPlayerDistance = Mathf.Pow(Mathf.Abs(transform.position.x - waterPlayer.transform.position.x), 2) +
                                    Mathf.Pow(Mathf.Abs(transform.position.y - waterPlayer.transform.position.y), 2);
        waterPlayerDistance = Mathf.Sqrt(waterPlayerDistance);
        if (order == 1) {
            if (elePlayerDistance < waterPlayerDistance)
            {
                return elePlayer;
            }
            return waterPlayer;
        } else{
            if (elePlayerDistance < waterPlayerDistance)
            {
                return waterPlayer;
            }
            return elePlayer;
        }
        
    }
    private bool CanSeePlayer(GameObject player) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), enemyScript.detectionRadius, ~enemyScript.layerToIgnore);
        if (hit.collider.tag == "Player")
        {
            return true;
        }
        return false;
    }
    public GameObject GetTargetPlayer() {
        if (CanSeePlayer(ClosestPlayer(1))) {
            return ClosestPlayer(1);
        }
        return ClosestPlayer(2);
    }
}
