using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = enemy.GetComponent<Enemy2>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.GetComponent<Enemy2>().enemyAlive == true)
        {
            transform.position = enemy.GetComponent<Enemy2>().transform.position;
        }
    }
}
