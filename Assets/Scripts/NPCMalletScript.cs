using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMalletScript : MonoBehaviour
{
    public float speed = 0.05f;
    public float movesum = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed);
        movesum += speed;
        if (movesum > 1.2)
        {
            speed = -0.05f;
        }
        else if(movesum < -1.2){
            speed = 0.05f;
        }
    }
}
