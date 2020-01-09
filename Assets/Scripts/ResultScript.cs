using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    public int score1;
    public int score2;
    public int score3;
    public int score4;
    // Start is called before the first frame update
    void Start()
    {
        score1 = manager.score[0];
        score2 = manager.score[1];
        score3 = manager.score[2];
        score4 = manager.score[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
