using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Megan Mix
// 12/8/23
// Controls movement for enemy 1.

public class Enemy1 : MonoBehaviour
{
    public bool enemyAlive = true;

    public GameObject[] wayPoints;
    public int nextWayPoint;
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        MoveToWayPoint();
    }
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
