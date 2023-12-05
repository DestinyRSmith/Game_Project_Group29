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

    private float startingX = 23.01f;
    private float startingZ = 8.1025f;

    // starting X for lvl 2 orange enemy: 24.8 / starting Z: 4.63

    public bool enemyAlive = true;

    public float firstStopZ = -2.5f;
    public float secondStopZ = -12f;
    public float thirdStopZ = -7.33f;
    public float fourthStopZ = -4.9f;
    public float fifthStopZ = 4f;
    public float sixthStopZ = 5f;

    public float firstStopX = 22f;
    public float secondStopX = 17.7f;
    public float thirdStopX = 19.35f;
    public float fourthStopX = 17.78f;
    public float fifthStopX = 20.4f;
    public float sixthStopX = 24.8f;
    public float speed = 2f;
    //public bool goingDown = true;
    //public bool goingUp = false;
    public bool movingX;
    public bool movingZ;

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        startingZ = transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        //GoingDOWN();

        //GoingUP();
        movingZ = true;
        MoveBack(sixthStopZ);
        movingX = true;
        MoveRight(sixthStopX);
        MoveBack(secondStopZ);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Person" && GetComponent<PlayerController1>().ableToKill == true)
        {
            enemyAlive = false;
        }
    }
    /*
    private void GoingDOWN()
    {
        if (goingDown)
        {
            //moves enemy from top position to bottom position
            if (transform.position.z >= sixthStopZ && transform.position.x >= startingX)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }

            // moves enemy from left position to right position
            else if (transform.position.x >= sixthStopX && transform.position.z <= sixthStopZ)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            //moves enemy from top position to bottom position
            else if (transform.position.z >= secondStopZ && transform.position.x <= sixthStopX)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }

            // moves the enemy from right position to left position
            else if (transform.position.x >= firstStopX && transform.position.z <= secondStopZ)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            // moves enemy from top position to bottom position
            else if (transform.position.z >= secondStopZ && transform.position.x <= firstStopX)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }

            // moves the enemy from right position to left position
            else if (transform.position.x >= secondStopX && transform.position.z <= secondStopZ)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            // changes the enemy's flow of direction so it doesn't get confused with
            // previous actions
            else
            {
                goingDown = false;
                goingUp = true;                
            }

        }
    }

    private void GoingUP()
    {
        if (goingUp)
        {
            // moves enemy from bottom position to top position
            if (transform.position.z <= thirdStopZ && transform.position.x <= secondStopX)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }

            // moves enemy from left position to right position
            // this if statement is conflicting with fourth if statement, need help
            else if (transform.position.x <= thirdStopX && transform.position.z >= thirdStopZ)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            // moves enemy from bottom position to top position
            else if (transform.position.z <= fourthStopZ && transform.position.x >= thirdStopX)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }

            // moves the enemy from right position to left position
            else if (transform.position.x >= fourthStopX && transform.position.z <= fourthStopZ)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            // moves enemy from bottom position to top position
            else if (transform.position.z <= fifthStopZ && transform.position.x >= fourthStopX)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }

            // moves enemy from left position to right position
            else if (transform.position.x <= fifthStopX && transform.position.z >= fifthStopZ)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            // moves enemy from bottom position to top position
            else if (transform.position.z <= startingZ && transform.position.x >= fifthStopX)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }

            // moves enemy from left position to right position
            else if (transform.position.x <= startingX && transform.position.z >= startingZ)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
    */

    private void MoveBack(float stopBackZ)
    {
        if (transform.position.z >= stopBackZ && movingX == false)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        movingZ = false;
    }

    private void MoveForwrd(float stopForwardZ)
    {
        movingZ = true;
        if (transform.position.z >= stopForwardZ && movingX == false)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        movingZ = false;
    }

    private void MoveRight(float stopRightX)
    {
        if (transform.position.x <= stopRightX && movingZ == false)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        movingX = false;
    }

    private void MoveLeft(float stopLeftX)
    {
        movingX = true;
        if (transform.position.x >= stopLeftX && movingZ == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        movingX = false;
    }
}