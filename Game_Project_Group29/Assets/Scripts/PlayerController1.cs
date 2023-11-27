using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Megan Mix
/// 11/22/23
/// Handles Player movement & Controls lives and damage/losing lives. 
/// </summary>
public class PlayerController1 : MonoBehaviour
{
    public float speed = 10f;
    public int greenKeysCollected = 0;
    public float lives = 3f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with a trigger");
        if (other.gameObject.tag == "GreenKey")
        {
            Debug.Log("Collided with a Green Key");
            greenKeysCollected++;
            other.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GreenDoor")
        {
            Doors collidedDoors = collision.gameObject.GetComponent<Doors>();
            //Is the object we collided with tagged with the tag GreenDoor
            Debug.Log("Collided with Green Door");
            //checked to see if we have greater than OR equal to the amount of keys needed to open the door
            if (greenKeysCollected >= collision.gameObject.GetComponent<Doors>().greenKeysNeeded)
            {
                //Disables door
                collision.gameObject.SetActive(false);
                //reduces the amount of keys we have by the amount used
                greenKeysCollected -= collision.gameObject.GetComponent<Doors>().greenKeysNeeded;
            }
            else
            {
                Debug.Log("Not enough keys! Go find more!");
            }
        }
    }

    public void LooseALife()
    {
        lives--;
        Debug.Log("You have " + lives + " lives left.");
    }

    public void Death()
    {
        if (lives <= 0)
        {
            //Load game over scene
            Debug.Log("You have died.");
        }
    }
}
