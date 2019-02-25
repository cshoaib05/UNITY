using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Vector3 pos,movement;
    void Start()
    {
        pos = transform.position;
        movement = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
       
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement = new Vector3(0.05f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            movement = new Vector3(-0.05f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement = new Vector3(0, +0.05f, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            movement = new Vector3(0, -0.05f, 0);
        }

        pos = transform.position + movement;
        transform.position = pos;

    }
}
