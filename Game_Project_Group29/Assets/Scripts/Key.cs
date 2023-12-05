using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Enemy2>().enemyAlive == true)
        {
            this.gameObject.SetActive(false);
            transform.position = GetComponent<Enemy2>().transform.position;
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
