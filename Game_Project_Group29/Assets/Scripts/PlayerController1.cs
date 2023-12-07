using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
/// <summary>
/// Megan Mix
/// 11/22/23
/// Handles Player movement & Controls lives and damage/losing lives. 
/// </summary>
/// Notes:/// <summary>
/// if (key input)
/// nameAnimation.Play("tag");
/// </summary>

public class PlayerController1 : MonoBehaviour
{
    public float regularSpeed = 10f;
    public float fasterSpeed = 15f;
    public int keysCollected = 0;
    public float lives = 3f;
    public float score = 0f;
    public bool ableToKill;
    private Vector3 startPos;
    public bool facingRight;
    public bool facingLeft;
    public Animation PickaxeHitAnim;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //when E is pressed, animation is played
        if (Input.GetKey(KeyCode.E))
        {
            PickaxeHitAnim.Play("PickaxeHitAnim");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            //Debug.Log("Collided with a Key");
            keysCollected++;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Coffee")
        {
            //Speed power up 
            //Debug.Log("Collided with Powerup");
            StartCoroutine(SpeedPowerUP());
        }
        if (other.gameObject.tag == "TrapDoor")
        {
            Debug.Log("Collided with Trap Door");
            LooseALife();
            Respawn();
        }

        if (other.gameObject.tag == "Bomb")
        {
            LooseALife();
            other.gameObject.SetActive(false);
            Debug.Log("A BOMB has exloded and took a life.");
        }

        if (other.gameObject.tag == "Point1")
        {
            score++;
            other.gameObject.SetActive(false);
            Debug.Log("Score: " + score);
        }

        //Debug.Log("Collided with a trigger");
        if (other.gameObject.tag == "Point5")
        {
            score += 5f;
            other.gameObject.SetActive(false);
            Debug.Log("Score: " + score);
        }

        //Debug.Log("Collided with a trigger");
        if (other.gameObject.tag == "Cherries")
        {
            StartCoroutine(KillPowerUP());
            other.gameObject.SetActive(false);
        }

        //Debug.Log("Collided with a trigger");
        if (other.gameObject.tag == "Heart")
        {
            lives++;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Enemy2")
        {
            if (ableToKill == true)
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                LooseALife();
            }
        }

        //Debug.Log("Collided with a trigger");
        if (other.gameObject.tag == "Door1")
        {
            SceneManager.LoadScene(2);
        }

        //Debug.Log("Collided with a trigger");
        if (other.gameObject.tag == "Door2")
        {
            SceneManager.LoadScene(3);
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
    public void Respawn()
    {
        transform.position = startPos;
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

    public IEnumerator KillPowerUP()
    {
        // able to kill
        ableToKill = true;
        Debug.Log("You are able to kill enemies.");
        yield return new WaitForSeconds(15);
        // not able to kill
        Debug.Log("You are NOT able to kill enemies.");
        ableToKill = false;
    }
}
