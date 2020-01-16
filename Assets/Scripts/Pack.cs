using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pack : MonoBehaviour
{
    public Color malletColor1;
    public Color malletColor2;
    public Color malletColor3;
    public Color malletColor4;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mallet1 = GameObject.Find("Mallet1");
        malletColor1 = mallet1.GetComponent<Renderer>().material.color;
        GameObject mallet2 = GameObject.Find("Mallet2");
        malletColor2 = mallet2.GetComponent<Renderer>().material.color;
        GameObject mallet3 = GameObject.Find("Mallet3");
        malletColor3 = mallet3.GetComponent<Renderer>().material.color;
        GameObject mallet4 = GameObject.Find("Mallet4");
        malletColor4 = mallet4.GetComponent<Renderer>().material.color;


    }

    // Update is called once per frame
    void Update()
    {
        if (-4 > this.transform.position.x)
        {
            Debug.Log("1");
            manager.score[2]--;
            ColorScore();
            Destroy(this.gameObject);
         }
        if (4 < this.transform.position.x)
        {
            Debug.Log("2");
            manager.score[1]--;
            ColorScore();
            Destroy(this.gameObject);
        }
        if (-4 > this.transform.position.z)
        {
            Debug.Log("3");
            manager.score[0]--;
            ColorScore();
            Destroy(this.gameObject);
        }
        if (4 < this.transform.position.z)
        {
            Debug.Log("4");
            manager.score[3]--;
            ColorScore();
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

    void ColorScore()
    {
        if (GetComponent<Renderer>().material.color == malletColor3)
        {
            manager.score[0]++;
        }

        if (GetComponent<Renderer>().material.color == malletColor2)
        {
            manager.score[1]++;
        }

        if (GetComponent<Renderer>().material.color == malletColor1)
        {
            manager.score[2]++;
        }

        if (GetComponent<Renderer>().material.color == malletColor4)
        {
            manager.score[3]++;
        }
    }
}

