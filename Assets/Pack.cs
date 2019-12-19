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
            Destroy(this.gameObject);
         }
        if (4 < this.transform.position.x)
        {
            Debug.Log("2");
            scoreScript.score[1]--;
            Destroy(this.gameObject);
        }
        if (-4 > this.transform.position.z)
        {
            Debug.Log("3");
            scoreScript.score[0]--;
            Destroy(this.gameObject);
        }
        if (4 < this.transform.position.z)
        {
            Debug.Log("4");
            scoreScript.score[3]--;
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
}
