using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 keyPos;

    // Start is called before the first frame update
    void Start()
    {
        keyPos = enemy.GetComponent<Enemy2>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        keyPos = enemy.GetComponent<Enemy2>().transform.position;
        if (keyPos.y <= 1.3f)
        {
            keyPos.y += 0.35f;

        }
        transform.position = keyPos;
    }
}
