using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Megan Mix
/// 11/22/23
/// Handles Player movement & Controls lives and damage/losing lives. 
/// </summary>
/// Notes:/// <summary>
/// public Animation nameAnimation;
/// 
/// if (key input)
/// nameAnimation.Play("tag");
/// </summary>

public class PlayerController1 : MonoBehaviour
{
    public float regularSpeed = 10f;
    public float fasterSpeed = 15f;
    public int keysCollected = 0;
    public float lives = 3f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            Debug.Log("Collided with a Key");
            keysCollected++;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Coffee")
        {
            //Speed power up 
            Debug.Log("Collided with Powerup");
            StartCoroutine(SpeedPowerUP());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Door1")
        {
            Doors collidedDoors = collision.gameObject.GetComponent<Doors>();
            //Is the object we collided with tagged with the tag GreenDoor
            Debug.Log("Collided with a Door1");
            //checked to see if we have greater than OR equal to the amount of keys needed to open the door
            if (keysCollected >= collision.gameObject.GetComponent<Doors>().keysNeeded)
            {
                //Disables door
                collision.gameObject.SetActive(false);
                //reduces the amount of keys we have by the amount used
                keysCollected -= collision.gameObject.GetComponent<Doors>().keysNeeded;
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
    public IEnumerator SpeedPowerUP()
    {
        regularSpeed = fasterSpeed;
        yield return new WaitForSeconds(15);
        regularSpeed = 10f;
    }
}
