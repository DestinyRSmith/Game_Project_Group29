using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

// Destiny Smith
// 11/1/23
// Main Player Controller Script

public class PlayerController : MonoBehaviour
{
    // variables for movement
    private Vector3 startPosition;
    public float jumpForce = 5f;
    public float jumpCount = 0f;
    private Rigidbody rigidBodyRef;
    public bool firstHit = true;
    public float speed = 10f;
    public float deathY = -10f;

    // variables for health
    public float lives = 3f;
    public bool canTakeDamage = true;
    public float healthPack = 15f;
    public float extraHealth = 100f;
    public bool hasExtraHealth = false;

    // variables for bullets
    public bool regularBullets = true;
    public bool heavyBullets = false;
    public GameObject bullet;
    public GameObject heavyBullet;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyRef = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //side to side movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }


        // Rspawns the player and take 15 HP if they fall off the map
        if (transform.position.y <= deathY)
        {
            lives -= 1f;
            transform.position = startPosition;
        }

        GameOver();

    }

    private void OnTriggerEnter(Collider other)
    {
        //if player gets hit they lose 15HP and blink for 5 seconds
        if (other.gameObject.tag == "Enemy")
        {
            if (firstHit == true)
            {
                lives = lives - 1f;
            }
            Debug.Log("Total HP = " + lives);

        }
        
        // Handles damage for Boss Enemy
        if (other.gameObject.tag == "BossEnemy")
        {
            if (firstHit == true)
            {
                lives = lives - 1f;
            }
            if (canTakeDamage == true)
            {
                //totalHP = totalHP - 20f;
            }
            Debug.Log("Total HP = " + lives);
        }

        // heals the player 15 HP
        if (other.gameObject.tag == "HealthPack")
        {
            if (lives <= 1f || hasExtraHealth == true && lives <= 3f)
            {
                lives = lives + healthPack;
                other.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Your health is too full.");
            }
        }

        // adds 100 HP to max health
        if (other.gameObject.tag == "ExtraHealth")
        {
            hasExtraHealth = true;
            lives = lives + 1f;
            other.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// When HP is zero or below, game over scene loads
    /// </summary>
    public void GameOver()
    {
        if (lives <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
