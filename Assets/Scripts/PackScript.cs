using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackScript : MonoBehaviour
{
    public GameObject Pack;
    private GameObject Clone;
    public float speed;
    public float time;
    public bool waitFlag;

    void Start()
    {
        speed = 5;
        Clone = Instantiate(Pack, new Vector3(0, 0.15f ,0), Quaternion.identity);
        Clone.transform.Rotate(new Vector3(0, Random.Range(360, -360), 0));
        Rigidbody rb = Clone.GetComponent<Rigidbody>();
        rb.AddForce(Clone.transform.forward * speed, ForceMode.Impulse);
    }

    void Update()
    {


        time = Mathf.Floor(Time.time);
        if (time % 4 == 0 && waitFlag == false && time != 0)
        {
            Clone = Instantiate(Pack, new Vector3(0, 0.15f, 0), Quaternion.identity);
            Clone.transform.Rotate(new Vector3(0, Random.Range(360, -360), 0));
            Clone.gameObject.tag = "nanndemoiiyo" + Random.Range(1, 2).ToString();
            Debug.Log(Clone.gameObject.tag);
            Rigidbody rb = Clone.GetComponent<Rigidbody>();
            rb.AddForce(Clone.transform.forward * speed, ForceMode.Impulse);
            waitFlag = true;
        } else if (time % 4 != 0) {
            waitFlag = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "goal")
        {
            Destroy(this);
        } 
    }
}
