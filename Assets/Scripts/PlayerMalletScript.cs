using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMalletScript : MonoBehaviour
{
    public float movesum = 0f;
    public float speed = 0.05f;

    void Start()
    {
        movesum = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.x >= 0.3f)
        {
            transform.Translate(Vector3.back * speed);
            movesum += speed;

            if (movesum >= 1.2)
            {
                speed = 0f;
            }
            else
            {
                speed = 0.05f;
            }
        }
        else if (Input.acceleration.x <= -0.3f)
        {
            
            transform.Translate(Vector3.forward * speed);
            movesum -= speed;

            if (movesum <= -1.2)
            {
                speed = 0f;
            }
            else
            {
                speed = 0.05f;
            }
        }
        else
        {
            speed = 0f;
        }
    }
}
