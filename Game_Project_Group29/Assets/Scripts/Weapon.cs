using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject player;
    public Vector3 weaponPos;
    public Quaternion weaponRot;
    public Animation PickaxeHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //follows player
        transform.position = player.GetComponent<PlayerController1>().transform.position;
        weaponPos = transform.position;
        transform.rotation = weaponRot;

        // when player faces right, pickaxe is one unit to the right
        if (player.GetComponent<PlayerController1>().facingRight == true)
        {
            weaponPos.x += 1f;
            transform.position = weaponPos;
            if (weaponRot.y != -90)
            {
                transform.Rotate(Vector3.up * -90);
            }
        }
        // when player faces left, pickaxe is one unit to the left and rotates 90 degrees
        if (player.GetComponent<PlayerController1>().facingLeft == true)
        {
            weaponPos.x -= 1f;
            transform.position = weaponPos;
            if (weaponRot.y != 90)
            {
                transform.Rotate(Vector3.up * 90);
            }

        }
        //when E is pressed, animation is played
        if (Input.GetKey(KeyCode.E))
        {
            PickaxeHit.Play("PickaxeHitAnim");
        }
    }
}
