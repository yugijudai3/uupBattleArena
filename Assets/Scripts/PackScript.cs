﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackScript : MonoBehaviour
{
    public GameObject Pack;

    void Start()
    {
        Instantiate(Pack, new Vector3(0, 0.15f ,0), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
