using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackScript : MonoBehaviour
{
    public GameObject Pack;
    private GameObject Clone;
    public float speed;

    void Start()
    {
        Clone = Instantiate(Pack, new Vector3(0, 0.15f ,0), Quaternion.identity);
        Clone.transform.Rotate(new Vector3(0, Random.Range(360, -360), 0));
        Rigidbody rb = Clone.GetComponent<Rigidbody>();
        rb.AddForce(Clone.transform.forward * 10, ForceMode.Impulse);
    }

    void Update()
    {
    }
}
