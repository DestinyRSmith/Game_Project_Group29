using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private float startingX;
    private float startingZ;
    public float firstStopZ = -2.5f;
    public float secondStopZ = -12f;
    public float thirdStopZ = -7.33f;
    public float firstStopX = 22f;
    public float secondStopX = 17.7f;
    public float lastStopX = 24.8f;
    public float speed = 2f;
    private bool moveForward = true;

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveForward)
        {
            // If the object is not farther than the start position + right travel distance,
            // it can move right
            if (transform.position.z >= firstStopZ && transform.position.x == lastStopX)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
            else
            {
                moveForward = false;
            }
            moveForward = true;

            if (transform.position.x <= firstStopX && transform.position.z == firstStopZ)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            

            if (transform.position.z >= secondStopZ && transform.position.x == firstStopX)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
            

            if (transform.position.x <= secondStopX && transform.position.z == secondStopZ)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            

            if (transform.position.z <= thirdStopZ && transform.position.x == secondStopX)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
            
        }
    }
}
