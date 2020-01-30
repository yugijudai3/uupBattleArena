using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    public int score1;
    public int score2;
    public int score3;
    public int score4;
    public Text playerText;
    public Text CPU1Text;
    public Text CPU2Text;
    public Text CPU3Text;
    // Start is called before the first frame update
    void Start()
    {
        score1 = manager.score[0];
        score2 = manager.score[1];
        score3 = manager.score[2];
        score4 = manager.score[3];

        playerText.text = score1.ToString();
        CPU1Text.text = score2.ToString();
        CPU2Text.text = score3.ToString();
        CPU3Text.text = score4.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
