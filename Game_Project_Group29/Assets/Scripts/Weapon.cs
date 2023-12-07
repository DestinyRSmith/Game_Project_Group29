using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject player;
    public Vector3 weaponPos;
    public Vector3 offset;
    

    // Start is called before the first frame update
    void Start()
    {
        //weaponPos = player.GetComponent<PlayerController1>().transform.position;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        /*weaponPos = player.GetComponent<PlayerController1>().transform.position;
        if (weaponPos.y <= 1.3f)
        {
            weaponPos.y += 0.35f;

        }
        transform.position = weaponPos;*/
    }
}
