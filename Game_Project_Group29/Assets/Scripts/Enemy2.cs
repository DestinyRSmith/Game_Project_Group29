using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    /// Destiny Smith
    /// 12/7/23
    /// Handles Enemy movements.

    public bool enemyAlive = true;

    public GameObject[] wayPoints;
    public int nextWayPoint;
    public float speed = 2f;

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
    /// Moves the Boss Enemey from last to position to the new position of the "WayPoint" gameobject
    /// </summary>

    private void MoveToWayPoint()
    {
        Vector3 targetPosition = wayPoints[nextWayPoint].transform.position;
        targetPosition.y = transform.position.y;
        Vector3 direction = (targetPosition - transform.position);
        if (direction.magnitude >= .1f)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
        else
        {
            transform.position = targetPosition;
            nextWayPoint++;
            if (nextWayPoint >= wayPoints.Length)
            {
                nextWayPoint = 0;
            }
        }
    }
}