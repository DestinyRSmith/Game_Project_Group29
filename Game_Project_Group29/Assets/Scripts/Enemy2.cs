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

    public float firstStopZ = 0f;    
    public float secondStopZ = 0f;
    public float thirdStopZ = 0f;
    public float fourthStopZ = 0f;
    public float fifthStopZ = 0f;
    public float sixthStopZ = 0f;
    // seventh stop = starting Z

    public float firstStopX = 0f;    
    public float secondStopX = 0f;
    public float thirdStopX = 0f;
    public float fourthStopX = 0f;
    public float fifthStopX = 0f;
    public float sixthStopX = 0f;
    // seventh stop = starting X

    public float speed = 2f;

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
        movingX = false;
        movingZ = true;
        MoveBack(firstStopZ);
        movingX = true;
        MoveRight(firstStopX);
        movingZ = true;
        MoveBack(secondStopZ);
        movingX = true;
        MoveLeft(secondStopX);
        movingZ = true;
        MoveBack(thirdStopZ);
        movingX = true;
        MoveLeft(secondStopX);
        movingZ = true;
        MoveForward(fourthStopZ);
        movingX = true;
        MoveRight(thirdStopX);
        movingX = true;
        MoveForward(fifthStopZ);
        movingX = true;
        MoveLeft(sixthStopX);
        movingZ = true;
        MoveForward(sixthStopZ);
        movingX = true;
        MoveRight(startingX);
        movingX = true;
        MoveForward(startingZ);
        movingX = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && GetComponent<PlayerController1>().ableToKill == true)
        {
            enemyAlive = false;
        }
    }

    private void MoveBack(float stopBackZ)
    {
        movingZ = true;
        if (transform.position.z >= stopBackZ && movingX == false)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        else
        {
            movingZ = false;
        }

    }

    private void MoveForward(float stopForwardZ)
    {
        movingZ = true;
        if (transform.position.z >= stopForwardZ && movingX == false)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        else
        {
            movingZ = false;
        }

    }

    private void MoveRight(float stopRightX)
    {
        movingX = true;
        if (transform.position.x <= stopRightX && movingZ == false)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            movingX = false;
        }

    }

    private void MoveLeft(float stopLeftX)
    {
        movingX = true;
        if (transform.position.x >= stopLeftX && movingZ == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            movingX = false;
        }

    }
}