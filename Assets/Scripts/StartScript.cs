﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        manager.score = new int[4];
    }

    public void OnClick()
    {
        SceneManager.LoadScene("gamescene");
    }
    public void Exit()
    {
        UnityEngine.Application.Quit();
    }
}
