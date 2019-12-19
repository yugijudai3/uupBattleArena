using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pack : MonoBehaviour
{
    [SerializeField] private manager scoreScript;
       // Start is called before the first frame update
    void Start()
    {
        GameObject managerObject = GameObject.Find("GameManager");
        scoreScript = managerObject.GetComponent<manager>();


    }

    // Update is called once per frame
    void Update()
    {
        if (-4 > this.transform.position.x)
        {
            Debug.Log("1");
            scoreScript.score[2]--;
            colorScore();
            Destroy(this.gameObject);
         }
        if (4 < this.transform.position.x)
        {
            Debug.Log("2");
            scoreScript.score[1]--;
            colorScore();
            Destroy(this.gameObject);
        }
        if (-4 > this.transform.position.z)
        {
            Debug.Log("3");
            scoreScript.score[0]--;
            colorScore();
            Destroy(this.gameObject);
        }
        if (4 < this.transform.position.z)
        {
            Debug.Log("4");
            scoreScript.score[3]--;
            colorScore();
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Mallet")
        {
            Debug.Log(collision.gameObject.GetComponent<Renderer>().material.color);
            GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.color;
        }
    }
    void colorScore()
    {
        if (GetComponent<Renderer>().material.color == new Color(1, 1, 1, 1))
        {
            scoreScript.score[0]++;
        }

        if (GetComponent<Renderer>().material.color == new Color(1, 0.537f, 0, 1))
        {
            scoreScript.score[1]++;
        }

        if (GetComponent<Renderer>().material.color == new Color(0.648f, 0, 1, 1))
        {
            scoreScript.score[2]++;
        }

        if (GetComponent<Renderer>().material.color == new Color(0.840f, 0.091f, 0.128f, 1))
        {
            scoreScript.score[3]++;
        }
    }
}

