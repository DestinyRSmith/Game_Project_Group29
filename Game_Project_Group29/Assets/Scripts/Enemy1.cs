using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 3f;
    public float startingX = 28.81f;
    public float startingZ = 0.26f;


    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enemyMove()
    {
        if(startingZ <= 2.18f)
        {
            moveUp();
        }
        else
        {

        }
        //move forward till Z = 2.18
        //move left till X = 27.32
        //move forward till Z = 4.63
        //move left till Z = 24.76
    }
    public void moveUp()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
    public void moveDown()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }
    public void moveRight()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    public void moveLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
