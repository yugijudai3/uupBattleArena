﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Exit()
    {
        Application.Quit();
    }

    void PlayAgain()
    {
        manager.score = new int[4];
    }
}