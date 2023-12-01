using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    // To reuse script: position the enemy to where you want it to stop, duplicate,
    // use the duplicated enemy to see where the enemy stops to change direction (Focus on X & Z).
    // Only change X & Z "Stop" variables to where you want the enemy to stop.
    // Only need one variable per new stop, Z is up & down, X is left and right.
    // Add or move if statements to match the path you want the enemy to go.

    private float startingX;
    //private float startingZ;

    // starting X for lvl 2 orange enemy: 24.8 / starting Z: 4.63

    public float firstStopZ = -2.5f;
    public float secondStopZ = -12f;
    public float thirdStopZ = -7.33f;
    public float fourthStopZ = -4.9f;
    public float firstStopX = 22f;
    public float secondStopX = 17.7f;
    public float thirdStopX = 19.35f;
    public float fourthStopX = 17.78f;
    public float lastStopX = 24.8f;
    public float speed = 2f;
    public bool goingDown = true;
    public bool goingUp = false;

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        //startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        GoingDOWN();

        if (goingUp)
        {
            // moves enemy from bottom position to top position
            if (transform.position.z <= thirdStopZ && transform.position.x <= secondStopX)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }

            // moves enemy from left position to right position
            if (transform.position.x <= thirdStopX && transform.position.z >= thirdStopZ)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            // moves enemy from bottom position to top position
            if (transform.position.z <= fourthStopZ && transform.position.x >= thirdStopX)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }

            // moves the enemy from right position to left position
            if (transform.position.x <= fourthStopX && transform.position.z >= fourthStopZ)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
    }

    private void GoingDOWN()
    {
        if (goingDown)
        {
            //moves enemy from top position to bottom position
            if (transform.position.z >= firstStopZ && transform.position.x >= startingX)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }

            // moves the enemy from right position to left position
            if (transform.position.x >= firstStopX && transform.position.z <= firstStopZ)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            // moves enemy from top position to bottom position
            if (transform.position.z >= secondStopZ && transform.position.x <= firstStopX)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }

            // moves the enemy from right position to left position
            if (transform.position.x >= secondStopX && transform.position.z <= secondStopZ)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            // changes the enemy's flow of direction so it doesn't get confused with
            // previous actions
            goingDown = false;
            goingUp = true;
        }
    }
}