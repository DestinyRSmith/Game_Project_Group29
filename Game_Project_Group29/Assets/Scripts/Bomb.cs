using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Smith, Destiny
// 11/26/2023
// Controls movement for the prefab "Bomb"
public class Bomb : MonoBehaviour
{
    public float travelDistanceRight = 3.5f;
    public float travelDistanceLeft = -4f;
    public float speed = 2f;
    private float startingX;
    private bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        // When the scene starts, store the intial x value of this object
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            // If the object is not farther than the start position + right travel distance,
            // it can move right
            if (transform.position.x <= startingX + travelDistanceRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                moveRight = false;
            }
        }
        else
        {
            // If the object is not farhter than the start pos + left trav dist, it can move left
            if (transform.position.x >= startingX + travelDistanceLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            // If the object goes too far left, tell it to move right
            else
            {
                moveRight = true;
            }
        }
    }
}
