using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerTEST : MonoBehaviour
{
    public float lives = 3f;
    public float score = 0f;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with a trigger");
        if (other.gameObject.tag == "Bomb")
        {
            LooseALife();
            other.gameObject.SetActive(false);
            Debug.Log("A BOMB has exloded and took a life.");
        }

        Debug.Log("Collided with a trigger");
        if (other.gameObject.tag == "Point1")
        {
            score++;
            other.gameObject.SetActive(false);
            Debug.Log("Score: " + score);
        }

        Debug.Log("Collided with a trigger");
        if (other.gameObject.tag == "Point5")
        {
            score += 5f;
            other.gameObject.SetActive(false);
            Debug.Log("Score: " + score);
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