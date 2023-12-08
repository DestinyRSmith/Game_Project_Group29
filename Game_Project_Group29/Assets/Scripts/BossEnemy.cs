using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Destiny Smith
/// 12/7/23
/// Handles Boos movements, damage for both boss and player, and loads scene when HP is at 0.
public class BossEnemy : MonoBehaviour
{

    public bool enemyAlive = true;
    public float bossHP = 10f;
    public GameObject playerCon;
    public PlayerController1 playConScript;

    public GameObject[] wayPoints;
    public int nextWayPoint;
    public float speed = 15f;
    public bool wait = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveToWayPoint();
    }

    /// <summary>
    /// Causes the boss to loose 1 HP when collided with pickaxe.
    /// Causes the player to loose 1 lives when collided with boss unless able to Kill is true.
    /// </summary>
    /// <param name="other"></param>

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerCon.GetComponent<PlayerController1>().ableToKill == true)
            {
                bossHP--;
            }
            else
            {
                playConScript.GetComponent<PlayerController1>().lives -= 1;
            }
        }

        if (other.gameObject.tag == "Weapon")
        {
            bossHP--;
        }

    }

    /// <summary>
    /// Moves the Boss Enemey from last to position to the new position of the "WayPoint" gameobject
    /// </summary>

    private void MoveToWayPoint()
    {
        Vector3 targetPosition = wayPoints[nextWayPoint].transform.position;
        //targetPosition.y = transform.position.y;
        Vector3 direction = (targetPosition - transform.position);
        if (direction.magnitude >= .1f && wait == false)
        {
            //StartCoroutine(WayPointDelay());
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
        else if (wait == false)
        {
            transform.position = targetPosition;
            nextWayPoint++;
            if (nextWayPoint >= wayPoints.Length)
            {
                nextWayPoint = 0;
            }
            wait = true;
            StartCoroutine(WayPointDelay());
        }
    }

    /// <summary>
    /// Causes a delay of 5 seconds between each movement
    /// </summary>
    /// <returns></returns>

    public IEnumerator WayPointDelay()
    {
        Debug.Log("Waiting.");
        wait = true;
        yield return new WaitForSeconds(5);
        wait = false;
    }
}