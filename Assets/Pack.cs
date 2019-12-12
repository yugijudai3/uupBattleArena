using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (-4 > this.transform.position.x)
        {
            Debug.Log("majika-");
            Destroy(this.gameObject);
         }
        if (4 < this.transform.position.x)
        {
            Debug.Log("majika-");

            Destroy(this.gameObject);
        }
        if (-4 > this.transform.position.z)
        {
            Debug.Log("majika-");

            Destroy(this.gameObject);
        }
        if (4 < this.transform.position.z)
        {
            Debug.Log("majika-");

            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Mallet")
        {
            GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.color;
        }
    }
}
