using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

/// Megan Mix & Destiny Smith
/// 12/7/23
/// Controls lives and damage/losing lives, weapon and enemy mechanic, collisions, powerups, and manages
/// when to load next scene. 

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
    public Animation pickaxeHitAnim;
    public GameObject door;
    public GameObject boss;


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
            pickaxeHitAnim.Play("PickaxeHitAnim");
        }

        Death();

        if (boss.GetComponent<BossEnemy>().bossHP <= 0f)
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(5);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            keysCollected++;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Coffee")
        {
            StartCoroutine(SpeedPowerUP());
            other.gameObject.SetActive(false);
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

        if (other.gameObject.tag == "Point5")
        {
            score += 5f;
            other.gameObject.SetActive(false);
            Debug.Log("Score: " + score);
        }

        if (other.gameObject.tag == "Cherries")
        {
            StartCoroutine(KillPowerUP());
            other.gameObject.SetActive(false);
        }

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

        if (other.gameObject.tag == "Enemy1")
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

        if (other.gameObject.tag == "Door1")
        {
            Doors otherDoors = door.GetComponent<Doors>();
            //Is the object we collided with tagged with the tag GreenDoor
            Debug.Log("Collided with a Door1");
            //checked to see if we have greater than OR equal to the amount of keys needed to open the door
            if (keysCollected >= door.GetComponent<Doors>().keysNeeded)
            {
                //Disables door
                other.gameObject.SetActive(false);
                //reduces the amount of keys we have by the amount used
                keysCollected -= door.GetComponent<Doors>().keysNeeded;
                SceneManager.LoadScene(2);
            }
            else
            {
                Debug.Log("Not enough keys! Go find more!");
            }
        }
        //Debug.Log("Collided with a trigger");
        if (other.gameObject.tag == "Door2")
        {
            Doors otherDoors = door.GetComponent<Doors>();
            //Is the object we collided with tagged with the tag GreenDoor
            Debug.Log("Collided with a Door2");
            //checked to see if we have greater than OR equal to the amount of keys needed to open the door
            if (keysCollected >= door.GetComponent<Doors>().keysNeeded)
            {
                //Disables door
                other.gameObject.SetActive(false);
                //reduces the amount of keys we have by the amount used
                keysCollected -= door.GetComponent<Doors>().keysNeeded;
                SceneManager.LoadScene(3);
            }
            else
            {
                Debug.Log("Not enough keys! Go find more!");
            }
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
                SceneManager.LoadScene(2);
            }
            else
            {
                Debug.Log("Not enough keys! Go find more!");
            }
        }

        if (collision.gameObject.tag == "Door2")
        {
            Doors collidedDoors = collision.gameObject.GetComponent<Doors>();
            //Is the object we collided with tagged with the tag GreenDoor
            Debug.Log("Collided with a Door2");
            //checked to see if we have greater than OR equal to the amount of keys needed to open the door
            if (keysCollected >= collision.gameObject.GetComponent<Doors>().keysNeeded)
            {
                //Disables door
                collision.gameObject.SetActive(false);
                //reduces the amount of keys we have by the amount used
                keysCollected -= collision.gameObject.GetComponent<Doors>().keysNeeded;
                SceneManager.LoadScene(3);
            }
            else
            {
                Debug.Log("Not enough keys! Go find more!");
            }
        }
    }

    /// <summary>
    /// Sends the player back to thier starting position.
    /// </summary>
    public void Respawn()
    {
        transform.position = startPos;
    }

    /// <summary>
    /// Subtracts one from player "lives".
    /// </summary>
    public void LooseALife()
    {
        lives--;
        Debug.Log("You have " + lives + " lives left.");
    }

    /// <summary>
    /// When lives is 0 or less, the game over scene is loaded.
    /// </summary>
    public void Death()
    {
        if (lives <= 0)
        {
            Debug.Log("You have died.");
            SceneManager.LoadScene(4);
        }
    }

    /// <summary>
    /// Increases player speed for a specific amount of time.
    /// </summary>
    /// <returns></returns>
    public IEnumerator SpeedPowerUP()
    {
        regularSpeed = fasterSpeed;
        yield return new WaitForSeconds(15);
        regularSpeed = 10f;
    }

    /// <summary>
    /// Gives the ability to kill enemies for a certain amount of time.
    /// </summary>
    /// <returns></returns>
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
